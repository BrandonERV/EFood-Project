using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Models.ViewModels;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin + "," + DS.Role_Maintenance)]
    public class UserDiscountTicketController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserDiscountTicketController(IWorkUnit workUnit, IWebHostEnvironment webHostEnvironment)
        {
            _workUnit = workUnit;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index(int? id)
        {
            DiscountTicket discountTicket = await _workUnit.DiscountTicket.get(id.GetValueOrDefault());

            ViewData["DiscountTicketName"] = discountTicket.Name;
            ViewData["DiscountTicketId"] = discountTicket.Id;

            HttpContext.Session.SetInt32("DiscountTicketId", id.GetValueOrDefault());

            return View(discountTicket);
        }

        public async Task<IActionResult> Upsert(int? id, int idDiscountTicket)
        {

            ViewData["DiscountTicketId"] = idDiscountTicket;
            UserDiscountTicketVM userDiscountTicketVM = new UserDiscountTicketVM()
            {

                UserDiscountTicket = new UserDiscountTicket
                {
                    TicketId = idDiscountTicket,
                    Ticket = await _workUnit.DiscountTicket.get(idDiscountTicket)

                },
                UserList = _workUnit.UserDiscountTicket.GetUserList("User"),
                DiscountTicketList = _workUnit.UserDiscountTicket.GetDiscountTicketList("DiscountTicket")

            };
            if (id == null)
            {
                //Crear nuevo producto
                return View(userDiscountTicketVM);
            }

            userDiscountTicketVM.UserDiscountTicket = await _workUnit.UserDiscountTicket.get(id.GetValueOrDefault());
            if (userDiscountTicketVM.UserDiscountTicket == null)
            {
                return NotFound();
            }
            return View(userDiscountTicketVM);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UserDiscountTicketVM userDiscountTicketVM)
        {

            if (ModelState.IsValid)
            {

                if (userDiscountTicketVM.UserDiscountTicket.Id == 0)
                {

                    await _workUnit.UserDiscountTicket.Add(userDiscountTicketVM.UserDiscountTicket);
                }
                TempData[DS.Successful] = "Tarjeta del procesador de pago guardada correctamente";
                await _workUnit.Save();
                return RedirectToAction("Index", new { id = userDiscountTicketVM.UserDiscountTicket.TicketId });
            }
            //si el modelo no es valido
            userDiscountTicketVM.UserList = _workUnit.UserDiscountTicket.GetUserList("User");
            userDiscountTicketVM.DiscountTicketList = _workUnit.UserDiscountTicket.GetDiscountTicketList("DiscountTicket");
            return View(userDiscountTicketVM);
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            int? discountTicketId = HttpContext.Session.GetInt32("DiscountTicketId");
            var all = await _workUnit.UserDiscountTicket.getAll(incluirPropiedades: "User,Ticket", filtro: d => d.TicketId == discountTicketId.Value);
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var UserDiscountTicketDb = await _workUnit.UserDiscountTicket.get(id);
            if (UserDiscountTicketDb == null)
            {
                return Json(new { success = false, message = "Error al borrar tarjeta del procesador de pago" });
            }

            _workUnit.UserDiscountTicket.Remove(UserDiscountTicketDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Tarjeta del procesador de pago borrada correctamente" });
        }

        #endregion


    }
}

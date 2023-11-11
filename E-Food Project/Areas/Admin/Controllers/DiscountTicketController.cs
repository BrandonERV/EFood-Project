using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountTicketController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public DiscountTicketController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            DiscountTicket discountTicket = new DiscountTicket();

            if (id == null)
            {
                //Crear nuevo tiquete

                return View(discountTicket);
            }
            //Editar tiquete
            discountTicket = await _workUnit.DiscountTicket.get(id.GetValueOrDefault());
            if (discountTicket == null)
            {
                return NotFound();
            }
            return View(discountTicket);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(DiscountTicket discountTicket)
        {

            if (ModelState.IsValid)
            {
                if (discountTicket.Id == 0)
                {
                    await _workUnit.DiscountTicket.Add(discountTicket);
                    TempData[DS.Successful] = "Tiquete creado exitosamente";
                }
                else
                {
                    _workUnit.DiscountTicket.Update(discountTicket);
                    TempData[DS.Successful] = "Tiquete actualizado exitosamente";
                }
                await _workUnit.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar Tiquete";
            return View(discountTicket);
        }



        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var all = await _workUnit.DiscountTicket.getAll();
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var discountTicketDb = await _workUnit.DiscountTicket.get(id);
            if (discountTicketDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el tiquete" });
            }
            _workUnit.DiscountTicket.Remove(discountTicketDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Tiquete borrado correctamente" });
        }

        [ActionName("NameValidate")]
        public async Task<IActionResult> NameValidate(string name, int id = 0)
        {
            bool value = false;
            var list = await _workUnit.DiscountTicket.getAll();
            if (id == 0)
            {
                value = list.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            }
            else
            {
                value = list.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim() && c.Id != id);
            }
            if (value)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }



        #endregion


    }
}

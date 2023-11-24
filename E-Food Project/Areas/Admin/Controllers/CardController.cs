using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin) ]
    public class CardController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public CardController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) {
            Card card = new Card();

            if (id == null) { 
                //Crear nueva Tarjeta
                
                return View(card);
            }
            //Editar Tarjeta
            card = await _workUnit.Card.get(id.GetValueOrDefault());
            if (card==null)
            {
                return NotFound();
            }
            return View(card);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Card card) { 

            if(ModelState.IsValid)
            {
                if (card.Id == 0)
                {
                    await _workUnit.Card.Add(card);
                    TempData[DS.Successful] = "Tarjeta creada exitosamente";
                }
                else
                {
                    _workUnit.Card.Update(card);
                    TempData[DS.Successful] = "Tarjeta actualizada exitosamente";
                }
                await _workUnit.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar Tarjeta";
            return View(card);
        }



        #region API

        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            var all = await _workUnit.Card.getAll();
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var cardDb = await _workUnit.Card.get(id);
            if (cardDb == null)
            {
                return Json(new { success = false, message = "Error al borrar la tarjeta" });
            }
            _workUnit.Card.Remove(cardDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Tarjeta borrada correctamente" });
        }

        [ActionName("NameValidate")]
        public async Task<IActionResult> NameValidate(string name, int id = 0) { 
            bool value=false;
            var list= await _workUnit.Card.getAll();
            if (id == 0)
            {
                value = list.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            }
            else {
                value = list.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim() && c.Id != id);
            }
            if (value) { 
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }



        #endregion


    }
}

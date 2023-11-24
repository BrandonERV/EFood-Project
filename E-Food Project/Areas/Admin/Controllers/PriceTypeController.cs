using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin + "," + DS.Role_Maintenance)]
    public class PriceTypeController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public PriceTypeController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) {
            PriceType priceType = new PriceType();

            if (id == null) { 
                //Crear nuevo tipo de precio
                
                return View(priceType);
            }
            //Editar Tarjeta
            priceType = await _workUnit.PriceType.get(id.GetValueOrDefault());
            if (priceType ==null)
            {
                return NotFound();
            }
            return View(priceType);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PriceType priceType) { 

            if(ModelState.IsValid)
            {
                if (priceType.Id == 0)
                {
                    await _workUnit.PriceType.Add(priceType);
                    TempData[DS.Successful] = "Tipo de precio creado exitosamente";
                }
                else
                {
                    _workUnit.PriceType.Update(priceType);
                    TempData[DS.Successful] = "Tipo de precio actualizado exitosamente";
                }
                await _workUnit.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar el tipo de precio";
            return View(priceType);
        }



        #region API

        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            var all = await _workUnit.PriceType.getAll();
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var PriceTypedDb = await _workUnit.PriceType.get(id);
            if (PriceTypedDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el tipo de precio" });
            }
            _workUnit.PriceType.Remove(PriceTypedDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Tipo de precio borrado correctamente" });
        }

        [ActionName("ValidateName")]
        public async Task<IActionResult> ValidateName(string name, int id = 0) { 
            bool value=false;
            var list= await _workUnit.PriceType.getAll();
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

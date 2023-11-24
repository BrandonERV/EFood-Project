using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin + "," + DS.Role_Maintenance)]
    public class FoodLineController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public FoodLineController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) {
            FoodLine foodline = new FoodLine();

            if (id == null) { 
                //Crear nueva Linea de Comida
                
                return View(foodline);
            }
            //Actualizar Linea de Comida
            foodline = await _workUnit.FoodLine.get(id.GetValueOrDefault());
            if (foodline ==null)
            {
                return NotFound();
            }
            return View(foodline);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FoodLine foodline) { 

            if(ModelState.IsValid)
            {
                if (foodline.Id == 0)
                {
                    await _workUnit.FoodLine.Add(foodline);
                    TempData[DS.Successful] = "Linea de Comida creada exitosamente";
                }
                else
                {
                    _workUnit.FoodLine.Update(foodline);
                    TempData[DS.Successful] = "Linea de Comida actualizada exitosamente";
                }
                await _workUnit.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar la Linea de Comida";
            return View(foodline);
        }



        #region API

        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            var all = await _workUnit.FoodLine.getAll();
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var FoodLinedDb = await _workUnit.FoodLine.get(id);
            if (FoodLinedDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el Linea de Comida" });
            }
            _workUnit.FoodLine.Remove(FoodLinedDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Linea de Comida borrado correctamente" });
        }

        [ActionName("ValidateName")]
        public async Task<IActionResult> ValidateName(string name, int id = 0) { 
            bool value=false;
            var list= await _workUnit.FoodLine.getAll();
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

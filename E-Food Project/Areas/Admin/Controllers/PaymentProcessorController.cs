using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    public class PaymentProcessorController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public PaymentProcessorController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) {
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            if (id == null) { 
                //Crear nuevo Procesador
                paymentProcessor.Status = true;
                return View(paymentProcessor);
            }
            //Editar procesador
            paymentProcessor = await _workUnit.PaymentProcessor.get(id.GetValueOrDefault());
            if (paymentProcessor == null)
            {
                return NotFound();
            }
            return View(paymentProcessor);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PaymentProcessor paymentProcessor) { 

            if(ModelState.IsValid)
            {
                if (paymentProcessor.Id == 0)
                {
                    await _workUnit.PaymentProcessor.Add(paymentProcessor);
                    TempData[DS.Successful] = "Procesador de pago creado exitosamente";
                }
                else
                {
                    _workUnit.PaymentProcessor.Update(paymentProcessor);
                    TempData[DS.Successful] = "Procesador de pago actualizado exitosamente";
                }
                await _workUnit.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al guardar Procesador de pago";
            return View(paymentProcessor);
        }



        #region API

        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            var all = await _workUnit.PaymentProcessor.getAll();
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var paymentProcessorDb = await _workUnit.PaymentProcessor.get(id);
            if (paymentProcessorDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el Procesador de pago" });
            }
            _workUnit.PaymentProcessor.Remove(paymentProcessorDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Procesador de pago borrado correctamente" });
        }


        [ActionName("NameValidate")]
        public async Task<IActionResult> NameValidate(string name, int id = 0) { 
            bool value=false;
            var list= await _workUnit.PaymentProcessor.getAll();
            if (id == 0)
            {
                value = list.Any(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
            }
            else {
                value = list.Any(p => p.Name.ToLower().Trim() == name.ToLower().Trim() && p.Id != id);
            }
            if (value) { 
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }



        #endregion


    }
}

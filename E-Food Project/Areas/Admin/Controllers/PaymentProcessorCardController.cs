using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Models.ViewModels;
using EFood.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentProcessorCardController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaymentProcessorCardController(IWorkUnit unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _workUnit = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index(int? id)
        {
            PaymentProcessor paymentProcessor = await _workUnit.PaymentProcessor.get(id.GetValueOrDefault());

            ViewData["PaymentProcessorName"] = paymentProcessor.Name;
            ViewData["PaymentProcessorId"] = paymentProcessor.Id;

            return View(paymentProcessor);
        }

        public async Task<IActionResult> Upsert(int? id, int idPaymentProcessor) 
        {
            
            ViewData["PaymentProcessorId"] = idPaymentProcessor;
            PaymentProcessorCardVM paymentProcessorCardVM = new PaymentProcessorCardVM()
            {
                
                PaymentProcessorCard = new PaymentProcessorCard
                {
                    PaymentProcessorId = idPaymentProcessor,
                    PaymentProcessor = await _workUnit.PaymentProcessor.get(idPaymentProcessor)
                    
                },
                CardList = _workUnit.PaymentProcessorCard.GetCardList("Card"),
                PaymentProcessorList = _workUnit.PaymentProcessorCard.GetPaymentProcessorList("PaymentProcessor")

            };
           if (id == null)
            {
                //Crear nuevo producto
                return View(paymentProcessorCardVM);
            }

            paymentProcessorCardVM.PaymentProcessorCard = await _workUnit.PaymentProcessorCard.get(id.GetValueOrDefault());
            if (paymentProcessorCardVM.PaymentProcessorCard == null)
            {
                return NotFound();
            }
            return View(paymentProcessorCardVM);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(PaymentProcessorCardVM paymentProcessorCardVM)
        {
            
            if (ModelState.IsValid)
            {
                
                if (paymentProcessorCardVM.PaymentProcessorCard.Id == 0)
                {

                    await _workUnit.PaymentProcessorCard.Add(paymentProcessorCardVM.PaymentProcessorCard);
                }
                TempData[DS.Successful] = "Tarjeta del procesador de pago guardada correctamente";
                await _workUnit.Save();
                return View("Index");
            }
            //si el modelo no es valido
            paymentProcessorCardVM.CardList = _workUnit.PaymentProcessorCard.GetCardList("Card");
            paymentProcessorCardVM.PaymentProcessorList = _workUnit.PaymentProcessorCard.GetPaymentProcessorList("PaymentProcessor");
            return View(paymentProcessorCardVM);
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        { 
            var all = await _workUnit.PaymentProcessorCard.getAll(incluirPropiedades:"Card,PaymentProcessor");
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var PaymentProcessorCardDb = await _workUnit.PaymentProcessorCard.get(id);
            if (PaymentProcessorCardDb == null)
            {
                return Json(new { success = false, message = "Error al borrar tarjeta del procesador de pago" });
            }
           
            _workUnit.PaymentProcessorCard.Remove(PaymentProcessorCardDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Tarjeta del procesador de pago borrada correctamente" });
        }

       



        #endregion


    }
}

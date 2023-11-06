using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Models.ViewModels;
using EFood.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductPriceController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductPriceController(IWorkUnit unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _workUnit = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id) 
        {
            ProductPriceVM productPriceVM = new ProductPriceVM()
            {
                ProductPrice = new ProductPrice(),
                PriceTypeList = _workUnit.ProductPrice.GetPriceTypesListDropDown("PriceType")

            };
           if (id == null)
            {
                //Crear nuevo producto
                return View(productPriceVM);
            }

            productPriceVM.ProductPrice = await _workUnit.ProductPrice.get(id.GetValueOrDefault());
            if (productPriceVM.ProductPrice == null)
            {
                return NotFound();
            }
            return View(productPriceVM);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductPriceVM productPriceVM)
        {
            if (ModelState.IsValid)
            {
                
                if (productPriceVM.ProductPrice.Id == 0)
                {
                    //Nuevo producto
   
                    await _workUnit.ProductPrice.Add(productPriceVM.ProductPrice);
                }
                else
                {
                    //Actualizar producto
     
                    _workUnit.ProductPrice.Update(productPriceVM.ProductPrice);

                }
                TempData[DS.Successful] = "Precio del producto guardado correctamente";
                await _workUnit.Save();
                return View("Index");
            }
            //si el modelo no es valido
            productPriceVM.PriceTypeList = _workUnit.ProductPrice.GetPriceTypesListDropDown("PriceType");
            return View(productPriceVM);
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        { 
            var all = await _workUnit.ProductPrice.getAll(incluirPropiedades:"PriceType");
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var ProductPriceDb = await _workUnit.ProductPrice.get(id);
            if (ProductPriceDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el precio del producto" });
            }
           
            _workUnit.ProductPrice.Remove(ProductPriceDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Precio del producto borrado correctamente" });
        }

       



        #endregion


    }
}

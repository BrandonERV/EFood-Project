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
    public class ProductPriceController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductPriceController(IWorkUnit unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _workUnit = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = await _workUnit.Product.get(id.GetValueOrDefault()),
                FoodLineList = _workUnit.Product.GetFoodLineListDropDown("FoodLine")

            };

            ViewData["ProductName"] = productVM.Product.Name;
            ViewData["ProductId"] = productVM.Product.Id;

            return View(productVM);
        }

        public async Task<IActionResult> Upsert(int? id, int idProducto) 
        {
            ViewData["ProductId"] = idProducto;
            ProductPriceVM productPriceVM = new ProductPriceVM()
            {
                
                ProductPrice = new ProductPrice
                {
                    ProductId = idProducto,
                    Product = await _workUnit.Product.get(idProducto)
                    
                },
                PriceTypeList = _workUnit.ProductPrice.GetPriceTypesListDropDown("PriceType"),
                ProductList = _workUnit.ProductPrice.GetProductsListDropDown("Product")

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
                return RedirectToAction("Index", new { id = productPriceVM.ProductPrice.ProductId });
            }
            //si el modelo no es valido
            productPriceVM.PriceTypeList = _workUnit.ProductPrice.GetPriceTypesListDropDown("PriceType");
            productPriceVM.ProductList = _workUnit.ProductPrice.GetProductsListDropDown("Product");
            return View(productPriceVM);
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        { 
            var all = await _workUnit.ProductPrice.getAll(incluirPropiedades:"PriceType,Product");
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


        [ActionName("ValidatePriceType")]
        public async Task<IActionResult> ValidatePriceType(int priceTypeId = 0)
        {
            bool value = false;
            var list = await _workUnit.ProductPrice.getAll();
            
            value = list.Any(p => p.PriceType.Id == priceTypeId);
            
            if (value)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }


        #endregion


    }
}

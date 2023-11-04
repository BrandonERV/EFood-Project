using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Models.ViewModels;
using EFood.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWorkUnit unidadTrabajo, IWebHostEnvironment webHostEnvironment)
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
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                FoodLineList = _workUnit.Product.GetFoodLineListDropDown("FoodLine")

            };
           if (id == null)
            {
                //Crear nuevo producto
                return View(productVM);
            }

            productVM.Product = await _workUnit.Product.get(id.GetValueOrDefault());
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (productVM.Product.Id == 0)
                {
                    //Nuevo producto
                    string uploads = webRootPath + DS.ImagesPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads,fileName+extension),FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    productVM.Product.Image = fileName + extension;
                    await _workUnit.Product.Add(productVM.Product);
                }
                else
                {
                    //Actualizar producto
                    var Objproduct = await _workUnit.Product.getFirst(p => p.Id == productVM.Product.Id, isTracking: false);
                    if (files.Count > 0)
                    {
                        string uploads = webRootPath + DS.ImagesPath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //borar imagen anterior
                        var previusFile = Path.Combine(uploads, Objproduct.Image);
                        if (System.IO.File.Exists(previusFile))
                        {
                            System.IO.File.Delete(previusFile);
                        }
                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }
                        productVM.Product.Image = fileName + extension;
                    } // caso de que no se actualice la imagen
                    else
                    {
                        productVM.Product.Image = Objproduct.Image;
                    }
                    _workUnit.Product.Update(productVM.Product);

                }
                TempData[DS.Successful] = "Producto guardado correctamente";
                await _workUnit.Save();
                return View("Index");
            }
            //si el modelo no es valido
            productVM.FoodLineList = _workUnit.Product.GetFoodLineListDropDown("FoodLine");
            return View(productVM);
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll()
        { 
            var all = await _workUnit.Product.getAll(incluirPropiedades:"FoodLine");
            return Json(new { data = all });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) { 

            var ProductDb = await _workUnit.Product.get(id);
            if (ProductDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el Producto" });
            }
            //Borrar imagen
            string uploads = _webHostEnvironment.WebRootPath + DS.ImagesPath;
            var previusFile = Path.Combine(uploads, ProductDb.Image);
            if (System.IO.File.Exists(previusFile))
            {
                System.IO.File.Delete(previusFile);
            }

            _workUnit.Product.Remove(ProductDb);
            await _workUnit.Save();
            return Json(new { success = true, message = "Producto borrado correctamente" });
        }

        [ActionName("ValidateName")]
        public async Task<IActionResult> ValidateName(string name, int id = 0) { 
            bool value=false;
            var list= await _workUnit.Product.getAll();
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

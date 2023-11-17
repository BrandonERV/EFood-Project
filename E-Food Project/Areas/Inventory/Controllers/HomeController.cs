using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Models.Specifications;
using EFood.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace E_Food_Project.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkUnit _workUnit;

        public HomeController(ILogger<HomeController> logger, IWorkUnit workUnit)
        {
            _logger = logger;
            _workUnit = workUnit;
        }


        public IActionResult Index(int pageNumber =1, string search ="", string currentSearch ="")
        {
            if (!string.IsNullOrEmpty(search))
            {
                pageNumber = 1;
            }
            else
            {
                search = currentSearch;
            }
            ViewData["BusquedaActual"] = search;

            if (pageNumber <1) { pageNumber = 1; }
            Parameters parameters = new Parameters
            {
                PageNumber = pageNumber,
                PageSize = 4
            };
            var result = _workUnit.Product.getAllPaginated(parameters);

            if (!string.IsNullOrEmpty(search))
            {
                result = _workUnit.Product.getAllPaginated(parameters,p => p.Description.Contains(search));
            }

            ViewData["TotalPaginas"] = result.MetaData.TotalPages;
            ViewData["TotalRegistros"] = result.MetaData.TotalCount;
            ViewData["PaginaSize"] = result.MetaData.PageSize;
            ViewData["PageNumber"] = pageNumber;
            ViewData["Previo"] = "disabled"; //clase para deshabilitar el boton
            ViewData["Siguiente"] = "";

            if (pageNumber > 1){ViewData["Previo"] = "";}
            if (result.MetaData.TotalPages <= pageNumber) { ViewData["Siguiente"] = "disabled";}
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
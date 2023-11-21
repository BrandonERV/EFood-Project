using EFood.DataAccess.Repository.IRepository;
using EFood.Models;
using EFood.Models.Specifications;
using EFood.Models.ViewModels;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace E_Food_Project.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkUnit _workUnit;

        [BindProperty]
        public ShoppingCartVM shoppingCartVM { get; set; }

        public HomeController(ILogger<HomeController> logger, IWorkUnit workUnit)
        {
            _logger = logger;
            _workUnit = workUnit;
        }


        public async Task<IActionResult> Index(int pageNumber =1, string search ="", string currentSearch ="")
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null) 
            {
                var cartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == claim.Value);
                var amountProducts = cartList.Count();
                HttpContext.Session.SetInt32(DS.ssShoppingCart, amountProducts);
            }

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

        public async Task<IActionResult> Detail(int id)
        {
            shoppingCartVM = new ShoppingCartVM();
            shoppingCartVM.Product = await _workUnit.Product.getFirst(p => p.Id == id, incluirPropiedades:"FoodLine");
            shoppingCartVM.ProductPrices = _workUnit.ProductPrice.GetProductPricesListByIdDropDown("ProductPrices", id);
            shoppingCartVM.ShoppingCart = new ShoppingCart()
            {
                Product = shoppingCartVM.Product,
                ProductId = shoppingCartVM.Product.Id
            };

            return View(shoppingCartVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Detail(ShoppingCartVM shoppingCartVM)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCartVM.ShoppingCart.UserId = claim.Value;

            ShoppingCart cartBD = await _workUnit.ShoppingCart.getFirst(c => c.UserId == claim.Value && 
                                                                        c.ProductId == shoppingCartVM.ShoppingCart.ProductId);

            if(cartBD == null) 
            {
                await _workUnit.ShoppingCart.Add(shoppingCartVM.ShoppingCart);
            }
            else
            {
                cartBD.Amount += shoppingCartVM.ShoppingCart.Amount;
                _workUnit.ShoppingCart.Update(cartBD);
            }

            await _workUnit.Save();
            TempData[DS.Successful] = "Producto agregado al Carro de Compras";

            var cartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == claim.Value);
            var amountProducts = cartList.Count();
            HttpContext.Session.SetInt32(DS.ssShoppingCart, amountProducts);

            return RedirectToAction("Index");
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
using EFood.DataAccess.Repository.IRepository;
using EFood.Models.ViewModels;
using EFood.models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using EFood.Utilities;
using EFood.Models;
using Newtonsoft.Json;

namespace E_Food_Project.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class CartController : Controller
    {
        private readonly IWorkUnit _workUnit;
        private Order Order;

        public ShoppingCartVM shoppingCartVM { get; set; }

        public CartController(IWorkUnit workUnit) { 
               _workUnit = workUnit;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shoppingCartVM = new ShoppingCartVM();
            shoppingCartVM.Order = new Order();
            shoppingCartVM.ShoppingCartList = await _workUnit.ShoppingCart.getAll(
                                                    u => u.UserId == claim.Value,
                                                    incluirPropiedades:"Product");

            shoppingCartVM.Order.Amount = 0;
            shoppingCartVM.Order.UserId= claim.Value;

            foreach (var list in shoppingCartVM.ShoppingCartList) {

                shoppingCartVM.Order.Amount += (list.Price * list.Amount);
            }

            return View(shoppingCartVM);
        }

        public async Task<IActionResult> increment(int cartId)
        {
            var shoppingCart = await _workUnit.ShoppingCart.getFirst(c => c.Id == cartId);
            shoppingCart.Amount += 1;
            await _workUnit.Save();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> decrement(int cartId)
        {
            var shoppingCart = await _workUnit.ShoppingCart.getFirst(c => c.Id == cartId);
            if(shoppingCart.Amount == 1) 
            {
                var shoppingCartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == shoppingCart.UserId);
                var productAmount = shoppingCartList.Count();
                _workUnit.ShoppingCart.Remove(shoppingCart);
                HttpContext.Session.SetInt32(DS.ssShoppingCart, productAmount - 1);
                await _workUnit.Save();
            }
            else
            {
                shoppingCart.Amount -= 1;
                await _workUnit.Save();
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> remove(int cartId)
        {
            var shoppingCart = await _workUnit.ShoppingCart.getFirst(c => c.Id == cartId);
            var shoppingCartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == shoppingCart.UserId);
            var productAmount = shoppingCartList.Count();
            _workUnit.ShoppingCart.Remove(shoppingCart);
            await _workUnit.Save();
            HttpContext.Session.SetInt32(DS.ssShoppingCart, productAmount - 1);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Proceed() {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shoppingCartVM = new ShoppingCartVM()
            {
                Order = new Order(),
                ShoppingCartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == claim.Value, incluirPropiedades: "Product")
            };

            shoppingCartVM.Order.Amount = 0;
            shoppingCartVM.Order.User = await _workUnit.User.getFirst(u => u.Id == claim.Value);

            foreach (var list in shoppingCartVM.ShoppingCartList)
            {
                shoppingCartVM.Order.Amount += (list.Price * list.Amount);
            }

            shoppingCartVM.Order.ClientName = shoppingCartVM.Order.User.Name;

            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCartVM));

            return View(shoppingCartVM);


        }
        public async Task<IActionResult> Pay()
        {
            var serializedCart = HttpContext.Session.GetString("ShoppingCart");
            if (serializedCart != null)
            {
                var shoppingCartVM = JsonConvert.DeserializeObject<ShoppingCartVM>(serializedCart);

                shoppingCartVM.CardList = _workUnit.PaymentProcessorCard.GetCardList("Card");

                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCartVM));


                return View(shoppingCartVM);
            }
            else { return View(null); }

        }

        public async Task<IActionResult> SetPaymentType(string paymentType)
        {
            var serializedCart = HttpContext.Session.GetString("ShoppingCart");
          
            var shoppingCartVM = JsonConvert.DeserializeObject<ShoppingCartVM>(serializedCart);

                
            shoppingCartVM.Order.PaymentType = paymentType;

                
            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCartVM));

                
            return RedirectToAction("PayOption");
            

            
        }

        public async Task<IActionResult> PayOption()
        {
            var serializedCart = HttpContext.Session.GetString("ShoppingCart");
            if (serializedCart != null)
            {
                var shoppingCartVM = JsonConvert.DeserializeObject<ShoppingCartVM>(serializedCart);



                if (shoppingCartVM.Order.PaymentType.Equals("Tarjeta de Crédito o Débito"))
                {
                    shoppingCartVM.Order.IsPayCash = false;
                    shoppingCartVM.Order.IsPayCheck = false;
                    return RedirectToAction("PayOptionCreditCard");
                }
                else if (shoppingCartVM.Order.PaymentType.Equals("Cheque Electrónico"))
                {
                    shoppingCartVM.Order.IsPayCash = false;
                    shoppingCartVM.Order.IsCard = false;
                    return RedirectToAction("PayOptionPayCheck");
                }
                else
                {
                    shoppingCartVM.Order.IsPayCheck = false;
                    shoppingCartVM.Order.IsCard = false;
                    return RedirectToAction("PayOptionFinal");
                }
            }
            else return View(null);
        }

        public async Task<IActionResult> PayOptionCreditCard()
        {
            var serializedCart = HttpContext.Session.GetString("ShoppingCart");
            var shoppingCartVM = JsonConvert.DeserializeObject<ShoppingCartVM>(serializedCart);

            return View(shoppingCartVM);


        }
        public async Task<IActionResult> PayOptionPayCheck()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shoppingCartVM = new ShoppingCartVM()
            {
                Order = new Order(),
                ShoppingCartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == claim.Value, incluirPropiedades: "Product"),
                CardList = _workUnit.PaymentProcessorCard.GetCardList("Card")
            };



            shoppingCartVM.Order.User = await _workUnit.User.getFirst(u => u.Id == claim.Value);



            return View(shoppingCartVM);


        }
        public async Task<IActionResult> PayOptionFinal()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shoppingCartVM = new ShoppingCartVM()
            {
                Order = new Order(),
                ShoppingCartList = await _workUnit.ShoppingCart.getAll(c => c.UserId == claim.Value, incluirPropiedades: "Product"),
                CardList = _workUnit.PaymentProcessorCard.GetCardList("Card")
            };


            shoppingCartVM.Order.User = await _workUnit.User.getFirst(u => u.Id == claim.Value);



            return View(shoppingCartVM);


        }
    }
}

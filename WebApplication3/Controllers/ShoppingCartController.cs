//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using WebApplication3.Models;
//using X.PagedList;
//using WebApplication3.Repository;

//namespace WebApplication3.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        private readonly ElectronicsContext _context;

//        private ShoppingCartRepository shoppingcartrepository;
//        public ShoppingCartController(ShoppingCartRepository repo)
//        {
//            shoppingcartrepository = repo;
//        }

//        public RedirectToActionResult AddToCart(int productId, string returnUrl)
//        {

//            Product product = shoppingcartrepository.GetShoppingCart().FirstOrDefault(p => p.ProductID == productId);
//            if (product != null)
//            {
//                ShoppingCart cart = GetCart();
//                cart.AddItem(product, 1);
//                SaveCart(cart);
//            }

//            return RedirectToAction("Index", new { returnUrl });
//        }
//        public RedirectToActionResult RemoveFromCart(int cartlineid, string returnUrl)
//        {
//            Product product = shoppingcartrepository.GetShoppingCart().FirstOrDefault(p => p.ProductID == productId);
//            if (product != null)
//            {
//                ShoppingCart shoppingcart = GetNewCart();
//                cart.RemoveItem(cartlineid);
//                SaveCart(shoppingcart);
//            }
//            return RedirectToAction("Index", new { returnUrl });
//        }
//        private ShoppingCart GetNewCart()
//        {
//            ShoppingCart shoppingcart = HttpContext.Session.GetJson<Cart>("ShoppingCart") ?? new ShoppingCart();
//            return cart;
//        }
//        private void SaveCart(ShoppingCart shoppingcart)
//        {
//            HttpContext.Session.SetJson("ShoppingCart", shoppingcart);
//        }
//    }
//}
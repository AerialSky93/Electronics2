using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Infrastructure;


namespace WebApplication3.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IProductRepository<Product> productrepository;
        private ShoppingCartRepository shoppingcartrepository;


        public ShoppingCartController(IProductRepository<Product> productrepo, ShoppingCartRepository shoppingcartrepo)
        {
            productrepository = productrepo;
            shoppingcartrepository = shoppingcartrepo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartIndexViewModel
            {
                ShoppingCartRepository = shoppingcartrepository,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            shoppingcartrepository.AddItem(productid, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int cartlineid, string returnUrl)
        {
            shoppingcartrepository.RemoveItem(cartlineid);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
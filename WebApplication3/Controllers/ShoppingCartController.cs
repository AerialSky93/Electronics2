using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IProductRepository<Product> productrepository;
        private IShoppingCartRepository shoppingcartrepository;


        public ShoppingCartController(IProductRepository<Product> productrepo, IShoppingCartRepository shoppingcartrepo)
        {
            productrepository = productrepo;
            shoppingcartrepository = shoppingcartrepo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View();
        }

        public RedirectToActionResult AddToCart(int productid)
        {
            shoppingcartrepository.AddItem(productid, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int cartlineid)
        {
            shoppingcartrepository.RemoveItem(cartlineid);

            return RedirectToAction("Index");
        }
    }
}
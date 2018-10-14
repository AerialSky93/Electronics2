using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;

namespace ElectronicsStore.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IProductRepository<Product> productRepository;
        private ShoppingCartRepository shoppingCartRepository;


        public ShoppingCartController(IProductRepository<Product> productRepository, ShoppingCartRepository shoppingCartRepository)
        {
            productRepository = productRepository;
            shoppingCartRepository = shoppingCartRepository;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCartRepository.GetShoppingCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = productRepository.GetById(productid);
            shoppingCartRepository.AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int cartlineid, string returnUrl)
        {
            shoppingCartRepository.RemoveItem(cartlineid);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
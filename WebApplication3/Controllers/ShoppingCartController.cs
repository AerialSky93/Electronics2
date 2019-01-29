using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;

namespace ElectronicsStore.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IProductRepository<Product> _productRepository;
        private ShoppingCartRepository _shoppingCartRepository;


        public ShoppingCartController(IProductRepository<Product> productRepository, ShoppingCartRepository shoppingCartRepository)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCartRepository.GetAll(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = _productRepository.GetById(productid);
            _shoppingCartRepository.AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int cartlineid, string returnUrl)
        {
            _shoppingCartRepository.RemoveItem(cartlineid);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
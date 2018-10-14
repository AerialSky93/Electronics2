
using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;

namespace ElectronicsStore.Components
{

    public class CartSummaryViewComponent : ViewComponent
    {
        private ShoppingCartRepository shoppingcartrepository;

        public CartSummaryViewComponent(ShoppingCartRepository cartService)
        {
            shoppingcartrepository = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(shoppingcartrepository);
        }
    }
}

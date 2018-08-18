using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;

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

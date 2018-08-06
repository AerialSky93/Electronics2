using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Components
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

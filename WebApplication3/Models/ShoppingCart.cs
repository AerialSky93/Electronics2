using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Models;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public class ShoppingCart : List<CartLine>
    {
        public ShoppingCart()
        {

        }

    }
}

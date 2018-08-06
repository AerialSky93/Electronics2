using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public class ShoppingCart : List<CartLine>
    {
        public ShoppingCart()
        {

        }

    }
}

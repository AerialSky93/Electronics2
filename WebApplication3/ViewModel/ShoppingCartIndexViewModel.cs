using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication3.Models;

namespace WebApplication3.Models
{

    public class ShoppingCartIndexViewModel
    {
        public ShoppingCartRepository ShoppingCartRepository { get; set; }
        public string ReturnUrl { get; set; }
    }
}

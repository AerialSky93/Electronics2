using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }


}

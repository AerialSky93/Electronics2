using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }


}

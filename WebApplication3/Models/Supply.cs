using System;
using System.Collections.Generic;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public partial class Supply
    {
        public int SupplyId { get; set; }
        public Vendor Vendor { get; set; }
        public Product Product { get; set; }
        public int SupplyQuantity { get; set; }
    }
}

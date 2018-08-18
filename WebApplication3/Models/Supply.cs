using System;
using System.Collections.Generic;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public partial class Supply
    {
        public int SupplyId { get; set; }
        public Vendor Vendor { get; set; }
        public Product Product { get; set; }
        public int SupplyQuantity { get; set; }
    }
}

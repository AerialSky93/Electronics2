using System;
using System.Collections.Generic;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public Supplier Supplier { get; set; }
        public int InventoryQuantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public partial class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
    }
}

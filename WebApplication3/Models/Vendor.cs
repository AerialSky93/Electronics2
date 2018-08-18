using System;
using System.Collections.Generic;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public partial class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
    }
}

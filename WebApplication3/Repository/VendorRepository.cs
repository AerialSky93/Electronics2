using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public class VendorRepository 
    {

        private readonly ElectronicsContext _context;

        public VendorRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public Vendor GetById(int vendorId)
        {
            return _context.Vendor.Find(vendorId);

        }


    }
}

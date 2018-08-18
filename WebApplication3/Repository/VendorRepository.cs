using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using X.PagedList;
using WebApplication3.Repository;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web.Http;
namespace WebApplication3.Repository
{
    public class SupplyRepository
    {
        private readonly ElectronicsContext _context;
        private ProductRepository productrepository;
        private VendorRepository vendorrepository;

        public SupplyRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<Supply> GetAllSupply()
        {
            return _context.Supply.ToList();
        }

        public void ProcessFiles(string filePath)
        {
            StreamReader reader = File.OpenText("filename.txt");

            List<VendorSupply> values = File.ReadAllLines(@"C:\Users\duttar\Desktop\filename3.txt")
                                            .Select(v => VendorSupply.FromCsv(v))
                                            .ToList();

            foreach (VendorSupply i in values)
            {
                var product = productrepository.GetById(i.ProductId);
                var vendor = vendorrepository.GetById(i.VendorId);
                _context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity });

            }

        }

        public IQueryable<Supply> Supply => _context.Supply;

        public Product GetById(int SupplyId)
        {
            return _context.Product.Find(SupplyId);

        }
    }
}

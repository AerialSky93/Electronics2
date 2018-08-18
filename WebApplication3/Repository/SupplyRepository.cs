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
    public class SupplyRepository : ISupplyRepository<Supply>
    {
        private readonly ElectronicsContext _context;
        public ProductRepository productrepository;
        public VendorRepository vendorrepository;


        public SupplyRepository(ElectronicsContext context)
        {
            _context = context;
            productrepository = new ProductRepository(_context);
            vendorrepository = new VendorRepository(_context);

        }

        public IEnumerable<Supply> GetAllSupply()
        {
            return _context.Supply.ToList();
        }

        public async void ProcessFiles(string filePath)
        {
            //StreamReader reader = File.OpenText("filename.txt");

            //List<VendorSupply> values = File.ReadAllLines(@"C:\Users\Ritwik\Desktop\filenametest.txt")
            //                                .Select(v => VendorSupply.FromCsv(v))
            //                                .ToList();


            List<VendorSupply> values = File.ReadAllLines(filePath)
                                            .Select(v => VendorSupply.FromCsv(v))
                                            .ToList();

            foreach (VendorSupply i in values)
            {
                var product = productrepository.GetById(i.ProductId);
                var vendor = vendorrepository.GetById(i.VendorId);
                _context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity });
                await _context.SaveChangesAsync();
            }

        }

        public IQueryable<Supply> Supply => _context.Supply;

        public Product GetById(int SupplyId)
        {
            return _context.Product.Find(SupplyId);

        }
    }
}

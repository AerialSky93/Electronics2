using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;
using ElectronicsStore.Service;
using Microsoft.Extensions.Logging;
//using ElectronicsStore.Service;

namespace ElectronicsStore.Repository
{
    public class SupplyRepository : ISupplyRepository<Supply>
    {
        private readonly ElectronicsContext _context;
        public ProductRepository productrepository;
        public VendorRepository vendorrepository;
        ILogger logger;

        //ParseVendorSupply parseVendorSupplytest = new ParseVendorSupply(logger);

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

        //public async void ProcessFiles(string filePath)
        //{
        //    //StreamReader reader = File.OpenText("filename.txt");

        //    //List<VendorSupply> values = File.ReadAllLines(@"C:\Users\Ritwik\Desktop\filenametest.txt")
        //    //                                .Select(v => VendorSupply.FromCsv(v))
        //    //                                .ToList();


        //    List<VendorSupply> values = File.ReadAllLines(filePath)
        //                                    .Select(v => ParseVendorSupply.FromCsv(v))
        //                                    .ToList();

        //    foreach (VendorSupply i in values)
        //    {
        //        var product = productrepository.GetById(i.ProductId);
        //        var vendor = vendorrepository.GetById(i.VendorId);
        //        _context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity });
        //        await _context.SaveChangesAsync();
        //    }

        //}

        public IQueryable<Supply> Supply => _context.Supply;

        public Product GetById(int SupplyId)
        {

            return _context.Product.Find(SupplyId);

        }
    }
}

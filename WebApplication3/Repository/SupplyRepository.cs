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

        public IQueryable<Supply> Supply => _context.Supply;

        public Product GetById(int SupplyId)
        {
            return _context.Product.Find(SupplyId);
        }
    }
}

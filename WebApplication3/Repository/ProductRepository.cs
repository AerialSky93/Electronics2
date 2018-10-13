using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;

namespace ElectronicsStore.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ElectronicsContext _context;
        public ProductRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Product.ToList();
        }

        public IQueryable<Product> Products => _context.Product;

        public Product GetById(int productid)
        {
            return _context.Product.Find(productid);
            
        }

    }
}

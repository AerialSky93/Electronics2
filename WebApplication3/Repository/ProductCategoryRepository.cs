using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;

namespace ElectronicsStore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository<ProductCategory>
    {
        private readonly ElectronicsContext _context;

        public ProductCategoryRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _context.ProductCategory.ToList();
        }

        public IQueryable<ProductCategory> ProductCategory => _context.ProductCategory;
    }
}

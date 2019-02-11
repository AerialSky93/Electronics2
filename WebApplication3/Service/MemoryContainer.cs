using System.Collections.Generic;
using ElectronicsStore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using ElectronicsStore.Repository;
using ElectronicsStore.Models;

namespace ElectronicsStore.Infrastructure
{
    public class MemoryContainer : IMemoryContainer
    {
        private readonly ElectronicsContext _context;
        public IMemoryCache MemCache;
        private IProductCategoryRepository<ProductCategory> _productCategoryRepository;

        public MemoryContainer(ElectronicsContext context, IMemoryCache memCache)
        {
            _context = context;
            MemCache = memCache;
            _productCategoryRepository = new ProductCategoryRepository(_context);
        }

        public void MemoryItemsExecute()
        {
            if (MemCache.Get<IEnumerable<ProductCategory>>("ProductCategoryList") == null)
            { 
                var productCategory = _productCategoryRepository.GetAll();
                MemCache.Set("ProductCategoryList", productCategory);
            }
        }
    }
}
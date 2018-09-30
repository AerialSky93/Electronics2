using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using ElectronicsStore.Repository;
using ElectronicsStore.Models;

namespace ElectronicsStore.Infrastructure
{
    public class ScheduledStuff : IScheduledStuff
    {
        private readonly ElectronicsContext _context;
        IMemoryCache MemCache;
        public IProductCategoryRepository<ProductCategory> productcategoryrepository;

        public ScheduledStuff(ElectronicsContext context, IMemoryCache memCache)
        {
            _context = context;
            MemCache = memCache;
            productcategoryrepository = new ProductCategoryRepository(_context);
        }

        public void ScheduleItemsExecute()
        {
            //System.NullReferenceException: 'Object reference not set to an instance of an object.'

            if (MemCache.Get<IEnumerable<ProductCategory>>("ProductCategoryList") == null)
            { 
                var testdata = productcategoryrepository.GetAllProductCategory();
                MemCache.Set("ProductCategoryList", testdata);
            }

        }
    }
}
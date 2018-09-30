using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using X.PagedList;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository<ProductCategory>
    {
        private readonly ElectronicsContext _context;

        public ProductCategoryRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            return _context.ProductCategory.ToList();
        }

        public IQueryable<ProductCategory> ProductCategory => _context.ProductCategory;

        //public Product GetById(int productid)
        //{
        //    return _context.Product.Find(productid);
            
        //}

    }
}

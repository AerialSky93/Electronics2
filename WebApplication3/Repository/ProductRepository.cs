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

namespace WebApplication3.Repository
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

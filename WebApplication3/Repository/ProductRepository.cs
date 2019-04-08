using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;
using AutoMapper;

namespace ElectronicsStore.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ElectronicsContext _context;
        public ProductRepository(ElectronicsContext context)
        {
            _context = context;
        }

        // to get all, use ToList
        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        // to get all, use ToList
        public IEnumerable<Product> GetAllByProductCategory(int productcategoryid)
        {

            return _context.Product.Where(p => p.ProductCategoryId == productcategoryid);
        }


        public IQueryable<Product> Products => _context.Product;

        public Product GetById(int productid)
        {
            return _context.Product.Find(productid);
            
        }
  
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }

        public void Edit(int productid, ProductViewModel productViewModel)
        {
            var config = new MapperConfiguration(cfg => {cfg.CreateMap<Product, ProductViewModel>();});
            Product product = _context.Product.Find(productid);
            IMapper iMapper = config.CreateMapper();

            var source = _context.Product.Find(productid); //new Product();

            var destination = iMapper.Map<Product, ProductViewModel>(source);

            //map the ViewModel to the model, use equality
            //save changes
            product.ProductName = productViewModel.ProductName;
            product.ProductDescription = productViewModel.ProductDescription;
            _context.SaveChangesAsync();
        }
    }
}

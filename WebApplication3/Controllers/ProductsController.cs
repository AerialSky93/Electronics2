using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using X.PagedList;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace ElectronicsStore.Controllers
{
    public class ProductsController : Controller
    {

        public ElectronicsContext _context;
        public IProductRepository<Product> productrepository;
        private IMemoryCache _cache;
        public IScheduledStuff _scheduledstuff;


        public ProductsController(IProductRepository<Product> repo, IMemoryCache memoryCache, IScheduledStuff scheduledstuff)
        {
            productrepository =repo;
            _cache = memoryCache;
            _scheduledstuff = scheduledstuff;
            _scheduledstuff.ScheduleItemsExecute();
        }

        // GET: Products
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var onePageOfProducts = productrepository.GetAllProduct().ToPagedList(pageNumber, pageSize);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            
            ViewBag.ProductCategoryList = _cache.Get<IEnumerable<ProductCategory>>("ProductCategoryList");
            
            return View();

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var product = productrepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

  
        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.ProductId == id);
        //}




        //// GET: Products/Details/5
        //public async Task<IActionResult> AddToCart(int productid)
        //{
        //    shoppingcartrepository.AddItem(productid,1);
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: ShoppingCart
        //public async Task<IActionResult> ViewShoppingCart()
        //{
        //    return View(shoppingcartrepository.GetShoppingCart());
        //}


    }
}

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
        public IProductRepository<Product> _ProductRepository;
        private IMemoryCache _memoryCache;
        public IScheduledStuff _scheduledstuff;


        public ProductsController(IProductRepository<Product> repo, IMemoryCache memoryCache, IScheduledStuff scheduledstuff)
        {
            _ProductRepository = repo;
            _memoryCache = memoryCache;
            _scheduledstuff = scheduledstuff;
            _scheduledstuff.ScheduleItemsExecute();
        }

        // GET: Products
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var onePageOfProducts = _ProductRepository.GetAllProduct().ToPagedList(pageNumber, pageSize);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            
            ViewBag.ProductCategoryList = _memoryCache.Get<IEnumerable<ProductCategory>>("ProductCategoryList");
            
            return View();

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var product = _ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}

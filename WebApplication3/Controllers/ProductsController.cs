using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using X.PagedList;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;

namespace ElectronicsStore.Controllers
{
    public class ProductsController : Controller
    {

        public ElectronicsContext _context;
        private IProductRepository<Product> _ProductRepository;
        private IMemoryCache _memoryCache;
        public IMemoryContainer _MemoryContainer;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository<Product> repo, IMemoryCache memoryCache, IMemoryContainer MemoryContainer, IMapper mapper)
        {
            _ProductRepository = repo;
            _memoryCache = memoryCache;
            _MemoryContainer = MemoryContainer;
            _MemoryContainer.MemoryItemsExecute();
            _mapper = mapper;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var onePageOfProducts = _ProductRepository.GetAll().ToPagedList(pageNumber, pageSize);

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


        // GET: Products1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _ProductRepository.GetById(id);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel = _mapper.Map<ProductViewModel>(product);

            if (product == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }


        // POST: Products1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, ProductViewModel productViewModel)
        {
            //if (id != product.ProductId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                _ProductRepository.Edit(id, productViewModel);
            }
            return RedirectToAction("Index", "Products");
        }


    }
}

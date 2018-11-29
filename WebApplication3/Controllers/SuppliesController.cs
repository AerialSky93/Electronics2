using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using ElectronicsStore.Service;

namespace ElectronicsStore.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ElectronicsContext _context;
        public ISupplyRepository<Supply> supplyrepository;
        public IProductRepository<Product> productrepository;

        public SuppliesController(ElectronicsContext context, ISupplyRepository<Supply> supplyrepo, IProductRepository<Product> productrepo)
        {
            _context = context;
            supplyrepository = supplyrepo;
            productrepository = productrepo;
        }
            

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post( List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            ParseVendorSupplyFile parseVendorSupplyFile = new ParseVendorSupplyFile();
            List < VendorSupply > vendorsupply = new List<VendorSupply>();

            vendorsupply = parseVendorSupplyFile.ProcessFiles(filePath);

            ParseVendorDatabase parseVendorDatabase = new ParseVendorDatabase(_context);
            parseVendorDatabase.CopytoDatabase(vendorsupply);

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }


        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyId,SupplyQuantity")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyId,SupplyQuantity")] Supply supply)
        {
            if (id != supply.SupplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.SupplyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply = await _context.Supply.FindAsync(id);
            _context.Supply.Remove(supply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
            return _context.Supply.Any(e => e.SupplyId == id);
        }
    }
}

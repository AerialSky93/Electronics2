using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;

namespace ElectronicsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesAPIController : ControllerBase
    {
        private readonly ElectronicsContext _context;

        public SuppliesAPIController(ElectronicsContext context)
        {
            _context = context;
        }

        // GET: api/Supplies1
        [HttpGet]
        public IEnumerable<Supply> GetSupply()
        {
            return _context.Supply;
        }

        // GET: api/Supplies1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupply([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supply = await _context.Supply.FindAsync(id);

            if (supply == null)
            {
                return NotFound();
            }

            return Ok(supply);
        }

        // PUT: api/Supplies1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply([FromRoute] int id, [FromBody] Supply supply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supply.SupplyId)
            {
                return BadRequest();
            }

            _context.Entry(supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Supplies1
        [HttpPost]
        public async Task<IActionResult> PostSupply([FromBody] Supply supply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Supply.Add(supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply", new { id = supply.SupplyId }, supply);
        }

        // DELETE: api/Supplies1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }

            _context.Supply.Remove(supply);
            await _context.SaveChangesAsync();

            return Ok(supply);
        }

        private bool SupplyExists(int id)
        {
            return _context.Supply.Any(e => e.SupplyId == id);
        }
    }
}
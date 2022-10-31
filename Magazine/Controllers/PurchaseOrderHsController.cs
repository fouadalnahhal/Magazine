using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magazine.Data;
using Magazine.Models;

namespace Magazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderHsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public PurchaseOrderHsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderH>>> GetPurchaseOrderH()
        {
            return await _context.PurchaseOrderH.ToListAsync();
        }

        // GET: api/PurchaseOrderHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderH>> GetPurchaseOrderH(int id)
        {
            var purchaseOrderH = await _context.PurchaseOrderH.FindAsync(id);

            if (purchaseOrderH == null)
            {
                return NotFound();
            }

            return purchaseOrderH;
        }

        // PUT: api/PurchaseOrderHs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderH(int id, PurchaseOrderH purchaseOrderH)
        {
            if (id != purchaseOrderH.ID)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderHExists(id))
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

        // POST: api/PurchaseOrderHs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderH>> PostPurchaseOrderH(PurchaseOrderH purchaseOrderH)
        {
            _context.PurchaseOrderH.Add(purchaseOrderH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseOrderH", new { id = purchaseOrderH.ID }, purchaseOrderH);
        }

        // DELETE: api/PurchaseOrderHs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrderH(int id)
        {
            var purchaseOrderH = await _context.PurchaseOrderH.FindAsync(id);
            if (purchaseOrderH == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderH.Remove(purchaseOrderH);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseOrderHExists(int id)
        {
            return _context.PurchaseOrderH.Any(e => e.ID == id);
        }
    }
}

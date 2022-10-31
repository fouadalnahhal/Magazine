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
    public class PurchaseOrderDsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public PurchaseOrderDsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderD>>> GetPurchaseOrderD()
        {
            return await _context.PurchaseOrderD.ToListAsync();
        }

        // GET: api/PurchaseOrderDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderD>> GetPurchaseOrderD(int id)
        {
            var purchaseOrderD = await _context.PurchaseOrderD.FindAsync(id);

            if (purchaseOrderD == null)
            {
                return NotFound();
            }

            return purchaseOrderD;
        }

        // PUT: api/PurchaseOrderDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderD(int id, PurchaseOrderD purchaseOrderD)
        {
            if (id != purchaseOrderD.ID)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderDExists(id))
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

        // POST: api/PurchaseOrderDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderD>> PostPurchaseOrderD(PurchaseOrderD purchaseOrderD)
        {
            _context.PurchaseOrderD.Add(purchaseOrderD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseOrderD", new { id = purchaseOrderD.ID }, purchaseOrderD);
        }

        // DELETE: api/PurchaseOrderDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrderD(int id)
        {
            var purchaseOrderD = await _context.PurchaseOrderD.FindAsync(id);
            if (purchaseOrderD == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderD.Remove(purchaseOrderD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseOrderDExists(int id)
        {
            return _context.PurchaseOrderD.Any(e => e.ID == id);
        }
    }
}

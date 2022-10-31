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
    public class MagazinePaymentsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public MagazinePaymentsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/MagazinePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazinePayment>>> GetMagazinePayment()
        {
            return await _context.MagazinePayment.ToListAsync();
        }

        // GET: api/MagazinePayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazinePayment>> GetMagazinePayment(int id)
        {
            var magazinePayment = await _context.MagazinePayment.FindAsync(id);

            if (magazinePayment == null)
            {
                return NotFound();
            }

            return magazinePayment;
        }

        // PUT: api/MagazinePayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazinePayment(int id, MagazinePayment magazinePayment)
        {
            if (id != magazinePayment.MagazinePaymentId)
            {
                return BadRequest();
            }

            _context.Entry(magazinePayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazinePaymentExists(id))
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

        // POST: api/MagazinePayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazinePayment>> PostMagazinePayment(MagazinePayment magazinePayment)
        {
            _context.MagazinePayment.Add(magazinePayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazinePayment", new { id = magazinePayment.MagazinePaymentId }, magazinePayment);
        }

        // DELETE: api/MagazinePayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazinePayment(int id)
        {
            var magazinePayment = await _context.MagazinePayment.FindAsync(id);
            if (magazinePayment == null)
            {
                return NotFound();
            }

            _context.MagazinePayment.Remove(magazinePayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazinePaymentExists(int id)
        {
            return _context.MagazinePayment.Any(e => e.MagazinePaymentId == id);
        }
    }
}

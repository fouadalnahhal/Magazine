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
    public class MagazineHeadsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public MagazineHeadsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/MagazineHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineHead>>> GetMagazineHead()
        {
            return await _context.MagazineHead.ToListAsync();
        }

        // GET: api/MagazineHeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineHead>> GetMagazineHead(int id)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(id);

            if (magazineHead == null)
            {
                return NotFound();
            }

            return magazineHead;
        }

        // PUT: api/MagazineHeads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazineHead(int id, MagazineHead magazineHead)
        {
            if (id != magazineHead.MagazineHeadId)
            {
                return BadRequest();
            }

            _context.Entry(magazineHead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineHeadExists(id))
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

        // POST: api/MagazineHeads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazineHead>> PostMagazineHead(MagazineHead magazineHead)
        {
            _context.MagazineHead.Add(magazineHead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazineHead", new { id = magazineHead.MagazineHeadId }, magazineHead);
        }

        // DELETE: api/MagazineHeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazineHead(int id)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(id);
            if (magazineHead == null)
            {
                return NotFound();
            }

            _context.MagazineHead.Remove(magazineHead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazineHeadExists(int id)
        {
            return _context.MagazineHead.Any(e => e.MagazineHeadId == id);
        }
    }
}

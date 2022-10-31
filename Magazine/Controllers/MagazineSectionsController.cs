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
    public class MagazineSectionsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public MagazineSectionsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/MagazineSections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineSection>>> GetMagazineSection()
        {
            return await _context.MagazineSection.ToListAsync();
        }

        // GET: api/MagazineSections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineSection>> GetMagazineSection(int id)
        {
            var magazineSection = await _context.MagazineSection.FindAsync(id);

            if (magazineSection == null)
            {
                return NotFound();
            }

            return magazineSection;
        }

        // PUT: api/MagazineSections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazineSection(int id, MagazineSection magazineSection)
        {
            if (id != magazineSection.MagazineSectionId)
            {
                return BadRequest();
            }

            _context.Entry(magazineSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineSectionExists(id))
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

        // POST: api/MagazineSections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazineSection>> PostMagazineSection(MagazineSection magazineSection)
        {
            _context.MagazineSection.Add(magazineSection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazineSection", new { id = magazineSection.MagazineSectionId }, magazineSection);
        }

        // DELETE: api/MagazineSections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazineSection(int id)
        {
            var magazineSection = await _context.MagazineSection.FindAsync(id);
            if (magazineSection == null)
            {
                return NotFound();
            }

            _context.MagazineSection.Remove(magazineSection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazineSectionExists(int id)
        {
            return _context.MagazineSection.Any(e => e.MagazineSectionId == id);
        }
    }
}

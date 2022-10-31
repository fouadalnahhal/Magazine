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
    public class MagazineSlidersController : ControllerBase
    {
        private readonly MagazineContext _context;

        public MagazineSlidersController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/MagazineSliders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineSlider>>> GetMagazineSlider()
        {
            return await _context.MagazineSlider.ToListAsync();
        }

        // GET: api/MagazineSliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineSlider>> GetMagazineSlider(int id)
        {
            var magazineSlider = await _context.MagazineSlider.FindAsync(id);

            if (magazineSlider == null)
            {
                return NotFound();
            }

            return magazineSlider;
        }

        // PUT: api/MagazineSliders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazineSlider(int id, MagazineSlider magazineSlider)
        {
            if (id != magazineSlider.MagazineSliderId)
            {
                return BadRequest();
            }

            _context.Entry(magazineSlider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineSliderExists(id))
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

        // POST: api/MagazineSliders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazineSlider>> PostMagazineSlider(MagazineSlider magazineSlider)
        {
            _context.MagazineSlider.Add(magazineSlider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazineSlider", new { id = magazineSlider.MagazineSliderId }, magazineSlider);
        }

        // DELETE: api/MagazineSliders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazineSlider(int id)
        {
            var magazineSlider = await _context.MagazineSlider.FindAsync(id);
            if (magazineSlider == null)
            {
                return NotFound();
            }

            _context.MagazineSlider.Remove(magazineSlider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazineSliderExists(int id)
        {
            return _context.MagazineSlider.Any(e => e.MagazineSliderId == id);
        }
    }
}

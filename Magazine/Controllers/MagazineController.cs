using Magazine.Data;
using Magazine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazineController : ControllerBase
    {
        private readonly MagazineContext _context;
        public MagazineController(MagazineContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineHead>> GetMerchantIdentity(int magazineId)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(magazineId);

            if (magazineHead == null)
            {
                return NotFound();
            }

            return magazineHead;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MagazineSlider>>> GetSliderImages(int magazineId)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(magazineId);

            if (magazineHead == null)
            {
                return NotFound();
            }

            return magazineHead.MagazineSliders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MagazineSection>>> GetAllSectionsAndItems(int magazineId)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(magazineId);

            if (magazineHead == null)
            {
                return NotFound();
            }

            return magazineHead.MagazineSections;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MagazinePayment>>> GetAllowedPaymentMethods(int magazineId)
        {
            var magazineHead = await _context.MagazineHead.FindAsync(magazineId);

            if (magazineHead == null)
            {
                return NotFound();
            }

            return magazineHead.MagazinePayments;
        }

        [HttpPost]
        public async Task<ActionResult<Returned>> SubmitOrder(Customer customer, PurchaseOrderH purchaseOrderH)
        {

            Returned returned = new Returned();
            return returned;
        }

        public class Returned
        {
            public bool IsSuccess { get; set; }
            public string MSG { get; set; }
        }
    }
}

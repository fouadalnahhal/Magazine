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
        public async Task<ActionResult<Obj>> SubmitOrder(Customer customer, PurchaseOrderH purchaseOrderH)
        {
            try
            {
                if (_context.Customer.SingleOrDefault(c => c.PhoneNumber == customer.PhoneNumber) == null)
                {
                    _context.Customer.Add(customer);
                    _context.SaveChangesAsync();
                }
                purchaseOrderH.Customer = customer;
                _context.PurchaseOrderH.Add(purchaseOrderH);
                _context.SaveChangesAsync();

                foreach (var item in purchaseOrderH.PurchaseOrderDs)
                {
                    item.PurchaseOrderHID = purchaseOrderH.ID;
                    _context.PurchaseOrderD.Add(item);
                }

                return new Obj() { IsSuccess = true, MSG = "Success" };
            }
            catch (Exception ex)
            {
                return new Obj() { IsSuccess = false, MSG = ex.Message };
                throw;
            }
        }

        public class Obj
        {
            public bool IsSuccess { get; set; }
            public string MSG { get; set; }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class MagazinePayment
    {
        public int MagazinePaymentId { get; set; }

        [MaxLength(500)]
        public string PaymentName { get; set; }

        [MaxLength(500)]
        public string PaymentIcon { get; set; }

        public int MagazineHeadId { get; set; }
        public MagazineHead MagazineHead { get; set; }
    }
}

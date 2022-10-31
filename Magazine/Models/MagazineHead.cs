using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class MagazineHead
    {
        public int MagazineHeadId { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Logo { get; set; }

        [MaxLength(500)]
        public string SaleTagColor { get; set; }

        [MaxLength(500)]
        public string ButtonColor { get; set; }

        [MaxLength(500)]
        public string FontColor { get; set; }

        [MaxLength(500)]
        public string Background { get; set; }

        public List<MagazineItem> MagazineItems { get; set; }
        public List<MagazineSection> MagazineSections { get; set; }
        public List<MagazineSlider> MagazineSliders { get; set; }
        public List<MagazinePayment> MagazinePayments { get; set; }
    }
}

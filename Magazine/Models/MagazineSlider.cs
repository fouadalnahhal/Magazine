using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class MagazineSlider
    {
        public int MagazineSliderId { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        public int MagazineHeadId { get; set; }
        public MagazineHead MagazineHead { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Magazine.Models
{
    public class MagazineSection
    {
        public int MagazineSectionId { get; set; }

        [MaxLength(500)]
        public string SectionName { get; set; }

        [MaxLength(500)]
        public string Section_Banner { get; set; }
        public int Section_Display { get; set; }

        public int MagazineHeadId { get; set; }
        public MagazineHead MagazineHead { get; set; }

        public List<MagazineItem> MagazineItems { get; set; }
    }
}

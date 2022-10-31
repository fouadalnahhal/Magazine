using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class MagazineItem
    {
        public int MagazineItemId { get; set; }
        public int ItemID { get; set; }

        [MaxLength(500)]
        public string ItemName { get; set; }

        [MaxLength(500)]
        public string ItemImage { get; set; }

        [Precision(18, 5)]
        public decimal ItemSalesPrice { get; set; }

        [Precision(18, 5)]
        public decimal ItemDiscountedPrice { get; set; }

        [Precision(18, 5)]
        public decimal ItemDiscountPercentage { get; set; }

        [Precision(18, 5)]
        public decimal ItemDiscountAmount { get; set; }

        [Precision(18, 5)]
        public decimal ItemMaximumOrderQty { get; set; }
        public int ItemDisplayOrder { get; set; }

        [MaxLength(500)]
        public string ItemDisplayName { get; set; }

        public int MagazineHeadId { get; set; }
        public MagazineHead MagazineHead { get; set; }
        public int MagazineSectionId { get; set; }
        public MagazineSection MagazineSection { get; set; }

    }
}

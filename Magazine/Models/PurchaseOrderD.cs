using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class PurchaseOrderD
    {
        public int ID { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }

        [MaxLength(50)]
        public string ItemID { get; set; }

        [Precision(18, 4)]
        public decimal Quantity { get; set; }
        public bool Taxable { get; set; }
        public decimal SalesTax { get; set; }

        [MaxLength(16)]
        public string ItemSubBarcode { get; set; }


        public int BranchId { get; set; }
        public int POSId { get; set; }
        public int UnitId { get; set; }

        [MaxLength(50)]
        public string UnitName { get; set; }

        [Precision(18, 4)]
        public decimal Equivalent { get; set; }
        public int BaseUnit { get; set; }
        public string ItemName { get; set; }
        public int MultiPackingItemID { get; set; }

        [Precision(18, 4)]
        public decimal ItmEqv { get; set; }

        [Precision(18, 4)]
        public decimal Total_Discount { get; set; }

        [Precision(18, 4)]
        public decimal Net_Total { get; set; }

        [Precision(18, 4)]
        public decimal Unit_Discount { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [MaxLength(50)]
        public string IMEINumber { get; set; }

        [MaxLength(500)]
        public string ItemComment { get; set; }
        public DateTime CreateDate { get; set; }

        [Precision(18, 4)]
        public decimal VATRate { get; set; }

        public int PurchaseOrderHID { get; set; }
        public PurchaseOrderH PurchaseOrderH { get; set; }
    }
}

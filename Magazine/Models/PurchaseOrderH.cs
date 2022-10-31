using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class PurchaseOrderH
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int DeliveryEmloyeeID { get; set; }
        public decimal Total { get; set; }
        public decimal SalesTax { get; set; }

        [Precision(18, 2)]
        public decimal DiscountPercent { get; set; }
        public decimal CashDiscount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DueAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Change { get; set; }
        public int SafeNumber { get; set; }
        public string Notes { get; set; }

        [MaxLength(50)]
        public string CreditCardTransactionNumber { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool Collected { get; set; }
        public bool Cancelled { get; set; }
        public byte OrderSource { get; set; }
        public string CustomerData { get; set; }
        public int PaymentMethod { get; set; }
        public string Status { get; set; }
        public int BranchId { get; set; }
        public int POSId { get; set; }
        public int ShiftId { get; set; }
        public int OrderIDEcommerce { get; set; }
        public int OrderItemsCountEcommerce { get; set; }
        public int OrderItemsCountPOS { get; set; }

        [MaxLength(100)]
        public string OrderType { get; set; }
        public bool UpdatedFromPOS { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int OpeningBalID { get; set; }
        public DateTime CollectedTime { get; set; }

        [Precision(18, 4)]
        public decimal DeliveryFees { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int TableNo { get; set; }
        public int WaiterID { get; set; }
        public bool Printed { get; set; }

        public int ClosingBalID { get; set; }

        public List<PurchaseOrderD> PurchaseOrderDs { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}

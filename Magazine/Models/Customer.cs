using System.ComponentModel.DataAnnotations;

namespace Magazine.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [MaxLength(10)]
        public string Titel { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Company { get; set; }

        [MaxLength(30)]
        public string EmailAddress { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string FaxNumber { get; set; }

        [MaxLength(500)]
        public string Address1 { get; set; }

        [MaxLength(500)]
        public string Address2 { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [MaxLength(20)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }
        public decimal PriceLevel { get; set; }
        public decimal Discount { get; set; }
        public decimal CreditLimit { get; set; }
        public int AccountBalance { get; set; }
        public int TotalSales { get; set; }
        public bool AllowCredit { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string PhoneNumber2 { get; set; }
        public DateTime LastVisitDate { get; set; }
        public string Notes { get; set; }
        public bool IsBlackList { get; set; }
        public int BranchId { get; set; }
        public int POSId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }
        public int Customer_Type { get; set; }
        public bool BlackList { get; set; }

        [MaxLength(500)]
        public string Address3 { get; set; }

        [MaxLength(20)]
        public string PhoneNumber3 { get; set; }

        [MaxLength(20)]
        public string PhoneNumber4 { get; set; }

        [MaxLength(20)]
        public string PhoneNumber5 { get; set; }
        public int SourceID { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDefault { get; set; }
        public bool Updated { get; set; }

        [MaxLength(500)]
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public int Ages { get; set; }
        public string NationalID { get; set; }

        public List<PurchaseOrderH> PurchaseOrderHs { get; set; }
    }
}

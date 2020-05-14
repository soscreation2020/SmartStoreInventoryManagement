using SmartStoreInventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Voucher:BaseEntity
    {
        public string VoucherNumber { get; set; }
        public int LPO { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountReleased { get; set; }
        public PaidStatus PaidStatus { get; set; }
        public string ChequeNo { get; set; }
        public string Comment { get; set; }
        public Guid? Bank_Id { get; set; }
        [ForeignKey("Bank_Id")]
        public Bank Bank { get; set; }
        public Guid? Vendor_Id { get; set; }
        [ForeignKey("Vendor_Id")]
        public Vendor Vendor { get; set; }
        public Guid? BankAccount_Id { get; set; }
        [ForeignKey("BankAccount_Id")]
        public BankAccount BankAccount { get; set; }
        public Guid? Branch_Id { get; set; }
        [ForeignKey("Branch_Id")]
        public Branch Branch { get; set; }
        public Guid? UserCreatedBy_Id { get; set; }
        [ForeignKey("UserCreatedBy_Id")]
        public MyAppUser UserCreatedBy { get; set; }
    }
}

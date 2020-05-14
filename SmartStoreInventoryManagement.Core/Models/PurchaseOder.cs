using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    public class PurchaseOder:BaseEntity
    {
        public string PurchaseOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime SupplyDate { get; set; }
        public int TaxAmt { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public Guid? UserCreatedBy_Id { get; set; }
        [ForeignKey("UserCreatedBy_Id")]
        public MyAppUser UserCreatedBy { get; set; }
        public Guid? Vendor_Id { get; set; }
        [ForeignKey("Vendor_Id")]
        public Vendor Vendor { get; set; }
        public Guid? Branch_Id { get; set; }
        [ForeignKey("Branch_Id")]
        public Branch Branch { get; set; }
        public ICollection<PurchaseOrderDetail> LineItems { get; set; }
    }
}

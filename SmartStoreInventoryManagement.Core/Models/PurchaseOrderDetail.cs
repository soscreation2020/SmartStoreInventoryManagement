using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class PurchaseOrderDetail:BaseEntity
    {
        public string OrderDetailNo { get; set; }
        public float VAT { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public float OrderQuantity { get; set; }
        public Guid? PurchaseOder_Id { get; set; }
        [ForeignKey("PurchaseOder_Id")]
        public PurchaseOder PurchaseOder { get; set; }
        public Guid? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}

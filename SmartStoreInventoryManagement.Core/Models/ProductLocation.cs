using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    public class ProductLocation : BaseEntity
    {
        public string RegNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityTransfered { get; set; }
        public DateTime TransferDate { get; set; }
        public Guid? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        public Guid? Store_Id { get; set; }
        [ForeignKey("Store_Id")]
        public Store Store { get; set; }
        public Guid? PreviousStore_Id { get; set; }
        [ForeignKey("PreviousStore_Id")]
        public Store PreviousStore { get; set; }
        public Guid? Branch_Id { get; set; }
        [ForeignKey("Branch_Id")]
        public Branch Branch { get; set; }

        public Guid? PreviousBranch_Id { get; set; }
        [ForeignKey("PreviousBranch_Id")]
        public Branch PreviousBranch { get; set; }

        public Guid? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? ProductSold { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}

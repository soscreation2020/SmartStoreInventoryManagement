using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class SellingPrice:BaseEntity
    {
        public string PriceNumber { get; set; }
        public string Name { get; set; }
        public DateTime SettingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public Guid? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        public Guid? UserCreatedBy_Id { get; set; }
        [ForeignKey("UserCreatedBy_Id")]
        public MyAppUser UserCreatedBy { get; set; }

    }
}

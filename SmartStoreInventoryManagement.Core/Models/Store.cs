using SmartStoreInventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Store:BaseEntity
    {
        public string StoreNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Boolean Active { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }
        public Guid? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        public Guid? ProductShelf_Id { get; set; }
        [ForeignKey("ProductShelf_Id")]
        public ProductShelf ProductShelf { get; set; }
        public Guid? UserCreatedBy_Id { get; set; }
        [ForeignKey("UserCreatedBy_Id")]
        public MyAppUser UserCreatedBy { get; set; }
        public Guid? Branch_Id { get; set; }
        [ForeignKey("Branch_Id")]
        public Branch Branch { get; set; }
        public Guid? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }
    }
}

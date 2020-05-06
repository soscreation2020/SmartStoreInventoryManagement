using SmartStoreInventoryManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
  public  class Product:BaseEntity
    {
        public string ProductNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TagNumber { get; set; }
        public string SerialNumber { get; set; }
        public int Period { get; set; }
        public ProductType productType { get; set; }
        public ProductStatus productstatus { get; set; }
        public string ReasonForInactivity { get; set; }
        public string RFID { get; set; }
        public string Barcode { get; set; }
        public string Color { get; set; }
        public int OpenBalance { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? UnitPrice { get; set; }
        public Boolean StockOutWarning { get; set; }
        public Guid? Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        public Guid? ProductLocation_Id { get; set; }
        [ForeignKey("ProductLocation_Id")]
        public ProductLocation ProductLocation { get; set; }
        public Guid? ProductShelf_Id { get; set; }
        [ForeignKey("ProductShelf_Id")]
        public ProductShelf ProductShelf { get; set; }
        public Guid? UnitOfMeasure_Id { get; set; }
        [ForeignKey("UnitOfMeasure_Id")]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}

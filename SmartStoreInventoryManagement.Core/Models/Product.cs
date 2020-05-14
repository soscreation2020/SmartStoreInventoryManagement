using SmartStoreInventoryManagement.Core.Enums;
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
        public Boolean Active { get; set; }
        public string RFID { get; set; }
        public string Barcode { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public int OpenBalance { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? UnitPrice { get; set; }
        public int StockOutWarning { get; set; }
        public int ReOrderPoint { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal VATRate { get; set; }
        public Guid? Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        public Guid? ProductShelf_Id { get; set; }
        [ForeignKey("ProductShelf_Id")]
        public ProductShelf ProductShelf { get; set; }
        public Guid? Staff_Id { get; set; }
        [ForeignKey("Staff_Id")]
        public Staff Staff { get; set; }

        public Guid? UnitOfMeasure_Id { get; set; }
        [ForeignKey("UnitOfMeasure_Id")]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}

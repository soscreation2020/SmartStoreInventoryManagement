using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public class ProductViewModel //: BaseViewModel
    {  
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductNo { get; set; }
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
        public Guid? Staff_Id { get; set; }
        public Guid? UnitOfMeasure_Id { get; set; }
        public Guid? ProductShelf_Id { get; set; }
        public int? TotalCount { get; set; }

        public static explicit operator Product(ProductViewModel source)
        {

            var destination = new Product
            {
                Id=source.Id,
                ProductNo = source.ProductNo,
                Name = source.Name,
                Description = source.Description,
                TagNumber = source.TagNumber,
                SerialNumber=source.SerialNumber,
                Period=source.Period,
                productType=source.productType,
                ReasonForInactivity = source.ReasonForInactivity,
                Active=source.Active,
                RFID=source.RFID,
                Barcode=source.Barcode,
                Class=source.Class,
                Style=source.Style,
                Color=source.Color,
                OpenBalance=source.OpenBalance,
                StandardCost=source.StandardCost,
                UnitCost=source.UnitCost,
                StockOutWarning=source.StockOutWarning,
                ReOrderPoint=source.ReOrderPoint,
                SellEndDate=source.SellEndDate,
                SellStartDate=source.SellStartDate,
                DiscountRate=source.DiscountRate,
                VATRate=source.VATRate,
                Category_Id=source.Category_Id,
                Staff_Id=source.Staff_Id,
                UnitOfMeasure_Id=source.UnitOfMeasure_Id,
                ProductShelf_Id=source.ProductShelf_Id,
                UnitPrice=source.UnitPrice,

            };
            return destination;


        }

    }
}

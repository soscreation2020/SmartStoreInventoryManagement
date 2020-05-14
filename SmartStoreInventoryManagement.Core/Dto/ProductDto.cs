using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Dto
{
   public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductNo { get; set; }
        public string Name { get; set; }
        public string Description{  get; set;}
        public decimal? UnitCost { get; set; }
        public decimal? UnitPrice { get; set; }
        public int StockOutWarning { get; set; }
        public int? TotalCount { get; set; }
    }
}

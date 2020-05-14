using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Dto
{
   public class UnitOfMeasureDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Decimals { get; set; }
        public String Symbol { get; set; }
        public int? TotalCount { get; set; }
        public string Date { get; set; }

       
    }
}

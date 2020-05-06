using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class UnitOfMeasure:BaseEntity
    {
        public String Symbol { get; set; }
        public String Name { get; set; }
        public int Decimals { get; set; }
    }
}

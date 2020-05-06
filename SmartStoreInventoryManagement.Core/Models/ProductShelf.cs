using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class ProductShelf:BaseEntity
    {
        public String RegNumber { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}

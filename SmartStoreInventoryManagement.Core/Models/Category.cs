using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Category:BaseEntity
    {
       public string CategorNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

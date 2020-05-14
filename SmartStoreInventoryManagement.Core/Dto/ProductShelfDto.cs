using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Dto
{
   public class ProductShelfDto
    {
        public Guid Id { get; set; }
        public string RegNumber { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public int? TotalCount { get; set; }
    }
}

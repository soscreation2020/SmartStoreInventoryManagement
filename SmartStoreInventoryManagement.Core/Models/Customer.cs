using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Customer:BaseEntity
    {
        public string CustomerNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Boolean IsMale { get; set; }
        public string TelNo { get; set; }
        public string Address { get; set; }
        public DateTime? DoB { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}

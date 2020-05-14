using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Bank:BaseEntity
    {
        public String RegNumber { get; set; }
        public String Name { get; set; }
        public String AbbrCode { get; set; }
        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }
}

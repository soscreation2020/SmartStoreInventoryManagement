using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class BankAccount:BaseEntity
    {
        public String RegNumber { get; set; }
        public String AccountNo { get; set; }
        public String Title { get; set; }
        public Guid? Bank_Id { get; set; }
        [ForeignKey("Bank_Id")]
        public Bank Bank { get; set; }
    }
}

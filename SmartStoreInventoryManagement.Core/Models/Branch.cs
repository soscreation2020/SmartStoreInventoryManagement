using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class Branch : BaseEntity
    {
        public String RegNumber { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Guid? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }
    }
}

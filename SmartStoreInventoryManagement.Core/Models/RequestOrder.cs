using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class RequestOrder:BaseEntity
    {
        public string RequestNumber { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public Guid? UserCreatedBy_Id { get; set; }
        [ForeignKey("UserCreatedBy_Id")]
        public MyAppUser UserCreatedBy { get; set; }
        public Guid? Store_Id { get; set; }
        [ForeignKey("Store_Id")]
        public Store Store { get; set; }
        public ICollection<RequestOrderDetail> RequestItems { get; set; }

    }
}

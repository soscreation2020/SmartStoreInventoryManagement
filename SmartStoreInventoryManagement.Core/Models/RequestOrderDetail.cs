using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
   public class RequestOrderDetail:BaseEntity
    {
        public string OrderDetailNo { get; set; }
        public int QuantityRequest { get; set; }
        public int QuantityReleased { get; set; }
        public Guid? RequestOrder_Id { get; set; }
        [ForeignKey("RequestOrder_Id")]
        public RequestOrder RequestOrder { get; set; }
        public Guid? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}

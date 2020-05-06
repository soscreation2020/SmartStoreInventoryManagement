using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    public class Company : BaseEntity
    {
       
        public String Name { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public String TaxId { get; set; }
        public String MobileNo { get; set; }
        public String OfficeNo { get; set; }
        public String EmailAddress { get; set; }
        public String Website { get; set; }


        //public virtual ICollection<Company_Currency> Currencies { get; set; }
    }
}


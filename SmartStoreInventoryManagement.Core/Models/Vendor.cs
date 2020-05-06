using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    public class Vendor : BaseEntity
    {
        public String RegNumber { get; set; }
        public String Number { get; set; }
        public String Name { get; set; }
        public String ContactPerson { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public String OfficeNumber { get; set; }
        public String ContactNumber { get; set; }
        public String Address { get; set; }
        public Guid Company_Id { get; set; }
        [ForeignKey("Company_Id")]
        public Company Company { get; set; }

        [ForeignKey("MyAppUser_Id")]
        public Guid MyAppUser_Id { get; set; }
        public MyAppUser MyAppUser { get; set; }


    }
}

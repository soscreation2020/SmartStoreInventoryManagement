using SmartStoreInventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    public class Staff : BaseEntity
    {
        public string Title { get; set; }
        public Guid User_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public MyAppUser User { get; set; }
        public string StaffNo { get; set; }
        public Guid? Branch_Id { get; set; }
        [ForeignKey("Branch_Id")]
        public Branch Branch { get; set; }
        public Guid? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficeNo { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Staff_Type Staff_Type { get; set; }
    }
}

using System;

namespace SmartStoreInventoryManagement.Core.Dto
{
    public class DepartmentDto 
    {
        public Guid Id { get; set; }
        public string RegNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int? TotalCount{ get; set;}
    }
}

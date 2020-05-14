using SmartStoreInventoryManagement.Core.Models;
using System;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public class DepartmentViewModel /*: BaseViewModel*/
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegNumber { get; set; }
        public int? TotalCount { get; set; }

        public static explicit operator Department(DepartmentViewModel source)
        {
            var destination = new Department
            {
                Id = source.Id,
                RegNumber = source.RegNumber,
                Name = source.Name,
                Description = source.Description,

            };
            return destination;
        }
    }
}

using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public class DepartmentListViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static explicit operator DepartmentListViewModel(Department source)
        {

            var destination = new DepartmentListViewModel
            {

            };
            return destination;
        }
    }
}

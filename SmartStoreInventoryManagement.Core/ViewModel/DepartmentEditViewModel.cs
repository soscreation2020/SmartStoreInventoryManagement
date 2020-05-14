using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public class DepartmentEditViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static explicit operator Department(DepartmentEditViewModel source)
        {

            var destination = new Department
            {


            };
            return destination;
        }

    }
}

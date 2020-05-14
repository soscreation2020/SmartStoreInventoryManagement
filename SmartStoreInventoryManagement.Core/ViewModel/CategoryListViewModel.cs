using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class CategoryListViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static explicit operator CategoryListViewModel(Category source)
        {

            var destination = new CategoryListViewModel
            {

            };
            return destination;
        }
    }
    
}

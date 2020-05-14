using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class CategoryEditViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static explicit operator Category(CategoryEditViewModel source)
        {

            var destination = new Category
            {


            };
            return destination;
        }
    }
}

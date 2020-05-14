using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class ProductShelfListViewModel : BaseViewModel
    {
    
        public string Name { get; set; }
        public string Description { get; set; }
        public static explicit operator ProductShelf(ProductShelfListViewModel source)
        {

            var destination = new ProductShelf
            {
                //Name = source.Name,
                //Description = source.Description,
            };
            return destination;
        }
    }
}

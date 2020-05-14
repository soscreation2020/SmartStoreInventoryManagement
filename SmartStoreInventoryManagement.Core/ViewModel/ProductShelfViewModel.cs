using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
  public  class ProductShelfViewModel //: BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegNumber { get; set; }
        public int? TotalCount { get; set; }
        public static explicit operator ProductShelf(ProductShelfViewModel source)
        {

            var destination = new ProductShelf
            {
                Id=source.Id,
                Name = source.Name,
                RegNumber=source.RegNumber,
                Description = source.Description,
            };
            return destination;
        }

    }
}

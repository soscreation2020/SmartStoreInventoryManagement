using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class CategoryViewModel //: BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryNo { get; set; }
        public string Description { get; set; }
        public int? TotalCount { get; set; }
        public static explicit operator Category(CategoryViewModel source)
        {

            var destination = new Category
            {
                Id=source.Id,
                Name = source.Name,
                Description = source.Description,
                CategorNumber=source.CategoryNo,
            };
            return destination;
        }
    
    }
}

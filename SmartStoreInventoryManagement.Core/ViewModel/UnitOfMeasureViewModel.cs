using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class UnitOfMeasureViewModel //: BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Decimals { get; set; }
        public String Symbol { get; set; }
        public int? TotalCount { get; set; }
        public static explicit operator UnitOfMeasure(UnitOfMeasureViewModel source)
        {

            var destination = new UnitOfMeasure
            {
                Id=source.Id,
                Name = source.Name,
                Decimals = source.Decimals,
                Symbol=source.Symbol,
            };
            return destination;
        }

    }
}

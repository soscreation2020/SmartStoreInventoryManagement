using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
   public class UnitOfMeasureEditViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public int Decimals { get; set; }
        public String Symbol { get; set; }
        public static explicit operator UnitOfMeasure(UnitOfMeasureEditViewModel source)
        {

            var destination = new UnitOfMeasure
            {
              

            };
            return destination;
        }

    }
}

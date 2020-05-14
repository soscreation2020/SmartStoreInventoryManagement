using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public class SearchViewModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string FilterBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public String Keyword { get; set; }
        public string EndDate { get; set; }
        public string startDate { get; set; }
      
        public SearchViewModel()
        {
            PageIndex = 1;
            PageSize = 25;
        }

    }
}

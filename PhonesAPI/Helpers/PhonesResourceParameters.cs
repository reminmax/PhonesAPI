using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Helpers
{
    public class PhonesResourceParameters
    {
        public string OS { get; set; }
        
        // searching
        public string SearchQuery { get; set; }

        // pagination
        private const int maxPageSize = 3;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 2;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        // sorting
        //public string OrderBy { get; set; } = "ModelName";

        // data shaping
        public string Fields { get; set; }
    }
}

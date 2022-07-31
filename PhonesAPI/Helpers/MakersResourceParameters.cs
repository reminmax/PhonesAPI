using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Helpers
{
    public class MakersResourceParameters
    {
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
        public string OrderBy { get; set; } = "Name";

        // data shaping
        public string Fields { get; set; }
    }
}

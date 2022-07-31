using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhonesAPI.Entities;

namespace PhonesAPI.Models
{
    public class PhoneDto
    {
        public Guid Id { get; set; }

        public string ModelName { get; set; }
        public int RamGb { get; set; }
        public string OS { get; set; }

        public string ReleasedMonthsAgo { get; set; }
        //public DateTime ReleaseDate { get; set; }

        public Maker Maker { get; set; }
        public Guid MakerId { get; set; }
    }
}

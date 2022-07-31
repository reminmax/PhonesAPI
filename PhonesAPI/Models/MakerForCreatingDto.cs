using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhonesAPI.Entities;

namespace PhonesAPI.Models
{
    public class MakerForCreatingDto
    {
        public string Name { get; set; }

        public ICollection<PhoneForCreatingDto> Phones { get; set; } = new List<PhoneForCreatingDto>();
    }
}

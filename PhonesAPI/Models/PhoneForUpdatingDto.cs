using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Models
{
    public class PhoneForUpdatingDto: PhoneManipulationDto
    {
        [Required(ErrorMessage = "RamGb needs to be filled in")]
        public override int RamGb
        {
            get => base.RamGb; 
            set => base.RamGb = value; 

        }
    }
}

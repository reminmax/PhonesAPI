using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhonesAPI.ValidationAttributes;

namespace PhonesAPI.Models
{
    [ModelNameAndOS(ErrorMessage = "Model name must be different from OS")]
    public abstract class PhoneManipulationDto
    {
        [Required(ErrorMessage = "Model name needs to be filled in")]
        [MaxLength(100, ErrorMessage = "Model name needs to be up to 100 characters")]
        public string ModelName { get; set; }

        public virtual int RamGb { get; set; }

        [Required(ErrorMessage = "OS needs to be filled in")]
        public string OS { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}

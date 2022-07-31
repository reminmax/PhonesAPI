using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Entities
{
    public class Phone
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; }

        public int RamGb { get; set; }
        
        [Required]
        public string OS { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [ForeignKey("MakerId")]
        public Maker Maker { get; set; }
        public Guid MakerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge6.Models
{
    public class Technology
    {
        [Key]
        [Required]
        public int TechonolgyId { get; set; }

        [Required]
        public string TechnologyName { get; set; }

    }
}

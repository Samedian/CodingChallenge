using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge6.Models
{
    public class Lead
    {
        [Key]
        [Required]
        public int LeadId { get; set; }

        [Required]
        public string LeadName { get; set; }

        [Required]
        public int technologyId { get; set; }
    }
}

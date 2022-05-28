using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge6.Models
{
    public class Candidate
    {
        [Key]
        [Required]
        public int CandidateId { get; set; }

        [Required]
        public string CandidateName { get; set; }

        [Required]
        public int LeadId { get; set; }

    }
}

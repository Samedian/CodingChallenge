using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallengeEntity
{
    [Serializable]
    public class LeadEntity
    {
        public int LeadId { get; set; }

        public string LeadName { get; set; }

        public int TechnologyId { get; set; }

    }
}

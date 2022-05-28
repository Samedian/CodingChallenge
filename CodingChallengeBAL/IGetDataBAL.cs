using CodingChallengeEntity;
using System.Collections.Generic;

namespace CodingChallengeBAL
{
    public interface IGetDataBAL
    {
        int CountByTechnology(int technologyId);
        List<CandidateEntity> GetCandidateByLead(int leadId);
        List<LeadEntity> GetLeadBAL();
        List<TechnologyEntity> GetTechnologyBAL();
    }
}
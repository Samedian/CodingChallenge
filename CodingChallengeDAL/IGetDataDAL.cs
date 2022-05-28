using CodingChallengeEntity;
using System.Collections.Generic;

namespace CodingChallengeDAL
{
    public interface IGetDataDAL
    {
        int CountByTechnology(int technologyId);
        List<CandidateEntity> GetCandidateByLead(int leadId);
        List<LeadEntity> GetLeadDAL();
        List<TechnologyEntity> GetTechnologyDAL();
    }
}
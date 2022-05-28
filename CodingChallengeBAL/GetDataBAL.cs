using CodingChallengeDAL;
using CodingChallengeEntity;
using System;
using System.Collections.Generic;

namespace CodingChallengeBAL
{
    public class GetDataBAL : IGetDataBAL
    {
        private readonly IGetDataDAL _getDataDAL;
        public GetDataBAL(IGetDataDAL getDataDAL)
        {
            _getDataDAL = getDataDAL;
        }
        public List<LeadEntity> GetLeadBAL()
        {
            List<LeadEntity> leadEntities = _getDataDAL.GetLeadDAL();
            return leadEntities;
        }

        public List<CandidateEntity> GetCandidateByLead(int leadId)
        {
            List<CandidateEntity> candidateEntities = _getDataDAL.GetCandidateByLead(leadId);
            return candidateEntities;
        }

        public List<TechnologyEntity> GetTechnologyBAL()
        {
            List<TechnologyEntity> technologyEntities = _getDataDAL.GetTechnologyDAL();
            return technologyEntities;
        }

        public int CountByTechnology(int technologyId)
        {
            int row = _getDataDAL.CountByTechnology(technologyId);
            return row;

        }

    }
}

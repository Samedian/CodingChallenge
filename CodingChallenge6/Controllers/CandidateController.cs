using CodingChallengeBAL;
using CodingChallengeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace CodingChallenge6.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        private readonly IGetDataBAL _getDataBAL;
        public CandidateController(IGetDataBAL getDataBAL)
        {
            _getDataBAL = getDataBAL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CandidateByLead()
        {
            List<LeadEntity> leadEntities = _getDataBAL.GetLeadBAL();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Lead.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, leadEntities);
            stream.Close();

            stream = new FileStream(@"D:\Lead.txt", FileMode.Open, FileAccess.Read);
            List<LeadEntity> objnew = (List<LeadEntity>)formatter.Deserialize(stream);


            ViewBag.Data = leadEntities;
            return View();
        }

        [HttpPost]
        public IActionResult CandidateByLead(int LeadId)
        {
            List<CandidateEntity> candidateEntities= _getDataBAL.GetCandidateByLead(LeadId);
            ShowCandidate(candidateEntities);
            return View("ShowCandidate");

        }

        public IActionResult ShowCandidate(List<CandidateEntity> candidateEntities)
        {
            ViewBag.Data = candidateEntities;
            return View();

        }

        [HttpGet]
        public IActionResult CountCandidateByTechnology()
        {
            List<TechnologyEntity> technologyEntities = _getDataBAL.GetTechnologyBAL();

            ViewBag.Data = technologyEntities;
            return View();
        }

        [HttpPost]
        public IActionResult CountCandidateByTechnology(int TechnologyId)
        {
            int  totalCandidate = _getDataBAL.CountByTechnology(TechnologyId);
            
            return View("ShowCountedCandidate");

        }

        public IActionResult ShowCountedCandidate(int count)
        {
            ViewBag.Data = count;
            return View("ShowCountedCandidate");

        }

    }
}

using GovInformer.Application.Adapters;
using GovInformer.Application.Congress;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GovInformer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongressController : ControllerBase
    {
        private readonly ILogger<CongressController> _logger;

        public CongressController(ILogger<CongressController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Senators")]
        public async Task<string> Senate()
        {
            var temp = await new CongressGatherer().GatherAllSenators();

            return JsonSerializer.Serialize(temp.Select(senator => new
            {
                GoveTrackID = senator.GovTrackID,
                FullName = senator.FirstName + " " + senator.LastName,
                Birthday = senator.Birthday.ToString(),
                senator.PhoneNumber,
                senator.Website,
                CongressType = senator.CongressType.ToString(),
                Party = senator.PoliticalParty.ToString(),
                StateTerritory = senator.StateTerritory.ToString(),
                SenateClass = senator.SenateClass.ToString(),
                TermStart = senator.TermStart.ToString("MM/dd/yyyyy"),
                TermEnd = senator.TermEnd.ToString("MM/dd/yyyy"),
                YearsOfSenatorExperience = senator.YearsOfSenatorExperience.ToString(),
            }));
        }

        [HttpGet]
        [Route("Representatives")]
        public async Task<string> Representatives()
        {
            var temp = await new CongressGatherer().GatherAllRepresentatives();

            return JsonSerializer.Serialize(temp.Select(senator => new
            {
                GoveTrackID = senator.GovTrackID,
                FullName = senator.FirstName + " " + senator.LastName,
                Birthday = senator.Birthday.ToString(),
                senator.PhoneNumber,
                senator.Website,
                CongressType = senator.CongressType.ToString(),
                Party = senator.PoliticalParty.ToString(),
                StateTerritory = senator.StateTerritory.ToString(),
                District = senator.District.ToString(),
                TermStart = senator.TermStart.ToString("MM/dd/yyyyy"),
                TermEnd = senator.TermEnd.ToString("MM/dd/yyyy"),
                YearsOfRepresentativeExperience = senator.YearsOfRepresentativeExperience.ToString(),
            }));
        }

        [HttpGet]
        [Route("Committees")]
        public async Task<string> Committees()
        {
            var temp = await new CongressGatherer().GatherAllCommittees();

            return JsonSerializer.Serialize(temp.Select(comm => new
            {
                CongressionalOwnership = comm.CongressType.ToString(),
                comm.ID,
                comm.Name,
                comm.Jurisdiction,
                comm.Website,
                comm.MinorityWebsite,
                comm.SubCommittees,
                comm.Address,
                comm.PhoneNumber
            }));
        }
    }
}

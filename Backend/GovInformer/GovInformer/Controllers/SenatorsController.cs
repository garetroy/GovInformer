using GovInformer.Application.Adapters;
using GovInformer.Application.Senators;
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
    public class SenatorsController : ControllerBase
    {
        private readonly ILogger<SenatorsController> _logger;

        public SenatorsController(ILogger<SenatorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var temp = await new SenatorGatherer().GatherAllSenators();

            return JsonSerializer.Serialize(temp.Legislators.Select(senator => new
            {
                FullName = senator.FirstName + " " + senator.LastName,
                Party = senator.PoliticalParty.ToString(),
                StateTerritory = senator.StateTerritory.ToString(),
                CongressType = senator.CongressType.ToString(),
                GoveTrackID = senator.GovTrackID
            }));
        }
    }
}

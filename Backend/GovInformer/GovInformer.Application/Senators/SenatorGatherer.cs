using GovInformer.Application.Adapters.SenateGov;
using GovInformer.Models.Common;
using GovInformer.Models.Senators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovInformer.Application.Senators
{
    public sealed class SenatorGatherer
    {
        public async Task<GatheredSenators> GatherAllSenators()
        {
            var result = await new SenateGovAdapter().GetAllSenators();

            var senators = new List<Senator>();
            foreach (var senator in result.Senators)
            {
                senators.Add(new Senator
                {
                    FirstName = senator.FirstName,
                    LastName = senator.LastName,
                    PoliticalParty = PoliticalParty.Parse(senator.Party.Length == 1 ? senator.Party[0] : '\0'),
                    StateTerritory = StateTerritory.Parse(senator.State),
                    SenatorId = senator.SenatorId
                });
            }

            return new GatheredSenators(senators);
        }
    }
}

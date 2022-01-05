using GovInformer.Application.Adapters.TheUnitedStatesIO;
using GovInformer.Models.Common;
using GovInformer.Models.Congress;
using System.Linq;
using System.Threading.Tasks;

namespace GovInformer.Application.Senators
{
    public sealed class SenatorGatherer
    {
        public async Task<GatheredLegisators> GatherAllSenators()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

            return new GatheredLegisators
            {
                Legislators = result.Select(leg =>
                    new Models.Congress.Legislator
                    {
                        FirstName = leg.Name.FirstName,
                        LastName = leg.Name.LastName,
                        CongressType = CongressType.Parse(leg.Terms.Last().CongressType),
                        PoliticalParty = PoliticalParty.Parse(leg.Terms.Last().PoliticalParty),
                        StateTerritory = StateTerritory.Parse(leg.Terms.Last().StateTerritory),
                        GovTrackID = leg.IDs.GovTrackID.ToString()
                    }
                ).Where(leg => leg.CongressType == CongressType.Senator).ToList()
            };
        }
    }
}

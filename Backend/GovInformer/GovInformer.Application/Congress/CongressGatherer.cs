using GovInformer.Application.Adapters.TheUnitedStatesIO;
using GovInformer.Models.Common;
using GovInformer.Models.Congress;
using GovInformer.Models.Congress.Representatives;
using GovInformer.Models.Congress.Senators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovInformer.Application.Congress
{
    public sealed class CongressGatherer
    {
        public async Task<List<Senator>> GatherAllSenators()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

            return
                result.Select(leg =>
                    new Senator
                    {
                        GovTrackID = leg.IDs.GovTrackID.ToString(),
                        FirstName = leg.Name.FirstName,
                        LastName = leg.Name.LastName,
                        Birthday = leg.Bio.Birthday,
                        PhoneNumber = leg.Terms.Last().PhoneNumber,
                        Website = leg.Terms.Last().SenatorSite,
                        CongressType = CongressType.Parse(leg.Terms.Last().CongressType),
                        PoliticalParty = PoliticalParty.Parse(leg.Terms.Last().PoliticalParty),
                        StateTerritory = StateTerritory.Parse(leg.Terms.Last().StateTerritory),
                        SenateClass = SenateClass.Parse(leg.Terms.Last().SenatorClass),
                        TermStart = leg.Terms.Last().TermStart,
                        TermEnd = leg.Terms.Last().TermEnd,
                        YearsOfSenatorExperience = leg.Terms.Where(term => CongressType.Parse(leg.Terms.Last().CongressType) == CongressType.Senator).Select(term => (int)((term.TermEnd - term.TermStart).TotalDays / 365.2425)).ToList().Sum(),
                    }
                ).Where(leg => leg.CongressType == CongressType.Senator).ToList();
        }

        public async Task<List<Representative>> GatherAllRepresentatives()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

            return
                result.Select(leg =>
                    new Representative
                    {
                        GovTrackID = leg.IDs.GovTrackID.ToString(),
                        FirstName = leg.Name.FirstName,
                        LastName = leg.Name.LastName,
                        Birthday = leg.Bio.Birthday,
                        PhoneNumber = leg.Terms.Last().PhoneNumber,
                        Website = leg.Terms.Last().SenatorSite,
                        CongressType = CongressType.Parse(leg.Terms.Last().CongressType),
                        PoliticalParty = PoliticalParty.Parse(leg.Terms.Last().PoliticalParty),
                        StateTerritory = StateTerritory.Parse(leg.Terms.Last().StateTerritory),
                        District = leg.Terms.Last().District,
                        TermStart = leg.Terms.Last().TermStart,
                        TermEnd = leg.Terms.Last().TermEnd,
                        YearsOfRepresentativeExperience = leg.Terms.Where(term => CongressType.Parse(leg.Terms.Last().CongressType) == CongressType.Representative).Select(term => (int)((term.TermEnd - term.TermStart).TotalDays / 365.2425)).ToList().Sum(),
                    }
                ).Where(leg => leg.CongressType == CongressType.Representative).ToList();
        }
    }
}

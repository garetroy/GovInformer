using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GovInformer.Application.Adapters.TheUnitedStatesIO
{
    internal sealed class TheUnitedStatesIOAdapter : BaseAdapter
    {
        public async Task<List<Legislator>> GetAllCurrentLegislators()
        {
            return await Get(CurrentLegislatorUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<List<Legislator>>(streamReader);
            });
        }

        public async Task<List<Committee>> GetAllCurrentCommittees()
        {
            return await Get(CurrentCommitteesUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<List<Committee>>(streamReader);
            });
        }

        public async Task<Dictionary<string, List<CommitteeMembership>>> GetAllCurrentCommitteeMembership()
        {
            return await Get(CurrentCommitteeMembershipUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<Dictionary<string, List<CommitteeMembership>>>(streamReader);
            });
        }

        private readonly string CurrentLegislatorUrl = "https://theunitedstates.io/congress-legislators/legislators-current.json";
        private readonly string CurrentCommitteesUrl = "https://theunitedstates.io/congress-legislators/committees-current.json";
        private readonly string CurrentCommitteeMembershipUrl = "https://theunitedstates.io/congress-legislators/committee-membership-current.json";
    }
}

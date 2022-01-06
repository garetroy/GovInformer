using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GovInformer.Application.Adapters.TheUnitedStatesIO
{
    internal sealed class TheUnitedStatesIOAdapter : BaseAdapter
    {
        public async Task<List<LegislatorDto>> GetAllCurrentLegislators()
        {
            return await Get(CurrentLegislatorUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<List<LegislatorDto>>(streamReader);
            });
        }

        public async Task<List<CommitteeDto>> GetAllCurrentCommittees()
        {
            return await Get(CurrentCommitteesUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<List<CommitteeDto>>(streamReader);
            });
        }

        public async Task<Dictionary<string, List<CommitteeMembershipDto>>> GetAllCurrentCommitteeMembership()
        {
            return await Get(CurrentCommitteeMembershipUrl, async streamReader =>
            {
                return await JsonSerializer.DeserializeAsync<Dictionary<string, List<CommitteeMembershipDto>>>(streamReader);
            });
        }

        private readonly string CurrentLegislatorUrl = "https://theunitedstates.io/congress-legislators/legislators-current.json";
        private readonly string CurrentCommitteesUrl = "https://theunitedstates.io/congress-legislators/committees-current.json";
        private readonly string CurrentCommitteeMembershipUrl = "https://theunitedstates.io/congress-legislators/committee-membership-current.json";
    }
}

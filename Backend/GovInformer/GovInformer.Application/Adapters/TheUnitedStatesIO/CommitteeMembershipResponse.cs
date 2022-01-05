using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GovInformer.Application.Adapters.TheUnitedStatesIO
{
    public sealed record CommitteeMembership
    {
        [JsonPropertyName("name")]
        public string MemberName { get; set; }

        [JsonPropertyName("party")]
        public string MajorityOrMinority { get; set; }

        [JsonPropertyName("rank")]
        public int CommitteeRank { get; set; }

        [JsonPropertyName("bioguide")]
        public string BioGuideID { get; set; }
    }
}

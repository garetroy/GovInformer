using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GovInformer.Application.Adapters.TheUnitedStatesIO
{
    internal sealed record SubCommitteeDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("thomas_id")]
        public string ID { get; set; }
    }

    internal sealed record CommitteeDto
    {
        [JsonPropertyName("thomas_id")]
        public string ID { get; set; }

        [JsonPropertyName("house_committee_id")]
        public string HouseID { get; set; }

        [JsonPropertyName("type")]
        public string CongressType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Website { get; set; }

        [JsonPropertyName("minority_url")]
        public string MinorityWebsite { get; set; }

        [JsonPropertyName("jurisdiction")]
        public string Jurisdiction { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("youtube_id")]
        public string YoutubeId { get; set; }

        [JsonPropertyName("subcommittees")]
        public List<SubCommitteeDto> SubCommittees { get; set; }
    }
}

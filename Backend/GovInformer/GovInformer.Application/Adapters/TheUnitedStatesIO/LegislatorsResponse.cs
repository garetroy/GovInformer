using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GovInformer.Application.Adapters.TheUnitedStatesIO
{
    public sealed record Term
    {
        // Representative or Senator
        [JsonPropertyName("type")]
        public string CongressType { get; set; }

        [JsonPropertyName("start")]
        public DateTime TermStart { get; set; }

        [JsonPropertyName("end")]
        public DateTime TermEnd { get; set; }

        [JsonPropertyName("state")]
        public string StateTerritory { get; set; }

        [JsonPropertyName("party")]
        public string PoliticalParty { get; set; }

        [JsonPropertyName("url")]
        public string SenatorSite { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        // Only relavant for Representatives
        [JsonPropertyName("district")]
        public int District { get; set; }

        // Only relevant for senators
        [JsonPropertyName("class")]
        public int SenatorClass { get; set; }
    }

    public sealed record Bio
    {
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }

    public sealed record Name
    {
        [JsonPropertyName("first")]
        public string FirstName { get; set; }

        [JsonPropertyName("last")]
        public string LastName { get; set; }
    }

    public sealed record ID
    {
        [JsonPropertyName("govtrack")]
        public int GovTrackID { get; set; }

        [JsonPropertyName("bioguide")]
        public string BioGuideID { get; set; }
    }

    public sealed record Legislator
    {
        [JsonPropertyName("id")]
        public ID IDs { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("bio")]
        public Bio Bio { get; set; }

        [JsonPropertyName("terms")]
        public List<Term> Terms { get; set; }

    }
}

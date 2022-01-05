using GovInformer.Models.Common;
using System;

namespace GovInformer.Models.Congress
{
    public record Legislator
    {
        public string GovTrackID { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime Birthday { get; init; }
        public string PhoneNumber { get; init; }
        public string Website { get; init; }
        public CongressType CongressType { get; init; }
        public PoliticalParty PoliticalParty { get; init; }
        public StateTerritory StateTerritory { get; init; }
        public DateTime TermStart { get; init; }
        public DateTime TermEnd { get; init; }
        public int YearsOfExperience { get; init; }
        public int YearsOfRepresentativeExperience { get; init; }
        public int YearsOfSenatorExperience { get; init; }
    }
}

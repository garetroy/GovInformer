using GovInformer.Models.Common;

namespace GovInformer.Models.Congress
{
    //TODO -- Make this class more robust
    public sealed record Legislator
    {
        public string GovTrackID { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public CongressType CongressType { get; init; }
        public PoliticalParty PoliticalParty { get; init; }
        public StateTerritory StateTerritory { get; init; }
        public int District { get; init; }
    }
}

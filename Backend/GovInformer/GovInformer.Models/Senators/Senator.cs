using GovInformer.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovInformer.Models.Senators
{
    public sealed record Senator
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public PoliticalParty PoliticalParty { get; init; }
        public StateTerritory StateTerritory { get; init; }
        public string SenatorId { get; init; }
    }
}

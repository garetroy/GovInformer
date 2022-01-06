using GovInformer.Models.Common;
using System.Collections.Generic;

namespace GovInformer.Models.Congress.Committees
{
    public sealed record Committee
    {
        public string ID { get; init; }
        public CongressType CongressType { get; init; }
        public string Name { get; init; }
        public string Website { get; init; }
        public string MinorityWebsite { get; init; }
        public string Jurisdiction { get; init; }
        public string PhoneNumber { get; init; }
        public string Address { get; init; }
        public HashSet<SubCommittees> SubCommittees { get; set; }

        /* For Legislator Model */
        public int CommitteeRank { get; init; }
        public bool LegislatorsRulingParty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GovInformer.Models.Congress.Committees
{
    public sealed record CommitteeMembership
    {
        public string MemberName { get; init; }
        public bool Majority { get; init; }
        public int CommitteeRank { get; init; }
        public string BioGuideID { get; init; }
    }
}

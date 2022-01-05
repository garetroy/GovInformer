using System;
using System.Collections.Generic;
using System.Text;

namespace GovInformer.Models.Congress.Committees
{
    public sealed class CommitteeMembership
    {
        public string MemberName { get; set; }
        public string MajorityOrMinority { get; set; }
        public int CommitteeRank { get; set; }
        public string BioGuideID { get; set; }
    }
}

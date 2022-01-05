using System;
using System.Collections.Generic;
using System.Text;

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
        public List<SubCommittees> SubCommittees { get; init; }
    }
}

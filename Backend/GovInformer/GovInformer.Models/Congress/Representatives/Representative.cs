
using GovInformer.Models.Congress.Committees;
using System.Collections.Generic;

namespace GovInformer.Models.Congress.Representatives
{
    public sealed record Representative : Legislator
    {
        public int District { get; init; }
        public int YearsOfRepresentativeExperience { get; init; }
    }
}

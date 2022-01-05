using GovInformer.Models.Common;
using System;

namespace GovInformer.Models.Congress.Senators
{
    public sealed record Senator : Legislator
    {
        public SenateClass SenateClass { get; init; }
    }
}

using GovInformer.Models.Common;
using System.Collections.Generic;

namespace GovInformer.Models.Congress.Senators
{
    public sealed record GatheredSenators
    {
        public GatheredSenators(List<Senator> senators)
        {
            Senators = senators;
        }

        public List<Senator> Senators { get; private set; }
    }
}

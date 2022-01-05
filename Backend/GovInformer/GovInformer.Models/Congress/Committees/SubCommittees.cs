using System;
using System.Collections.Generic;
using System.Text;

namespace GovInformer.Models.Congress.Committees
{
    public sealed record SubCommittees
    {
        public string ID { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string Phone { get; init; }
    }
}

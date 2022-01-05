using System;

namespace GovInformer.Models.Common
{
    public sealed record PoliticalParty
    {
        private PoliticalParty() { }

        private enum PoliticalPartyEnum
        {
            Unknown = 1,
            Democrat = 2,
            Republican = 3,
        };

        public static PoliticalParty Republican() => new PoliticalParty { PartyName = "Republican", Party = PoliticalPartyEnum.Republican };
        public static PoliticalParty Democrat() => new PoliticalParty { PartyName = "Democrat", Party = PoliticalPartyEnum.Democrat };
        public static PoliticalParty Unknown() => new PoliticalParty { PartyName = "Unknown", Party = PoliticalPartyEnum.Unknown };
        public bool Equals(PoliticalParty obj) => obj == null && Party == obj.Party;
        public override int GetHashCode() => Party.GetHashCode();
        public override string ToString() => PartyName;

        public static PoliticalParty Parse(char partyLetter) => char.ToLower(partyLetter) switch
        {
            'd' => Democrat(),
            'r' => Republican(),
            _ => Unknown()
        };

        private string PartyName { get; init; }
        private PoliticalPartyEnum Party { get; init; }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace GovInformer.Models.Congress
{
    public sealed record CongressType
    {
        private CongressType() { }

        private enum CongressTypeEnum
        {
            Unknown = 1,
            Representative = 2,
            Senator = 3,
            Joint = 4,
        };

        public static CongressType Representative => new CongressType { HouseName = "Representative", HouseType = CongressTypeEnum.Representative };
        public static CongressType Senator => new CongressType { HouseName = "Senator", HouseType = CongressTypeEnum.Senator };
        public static CongressType Joint => new CongressType { HouseName = "Senator", HouseType = CongressTypeEnum.Joint };
        public static CongressType Unknown => new CongressType { HouseName = "Unknown", HouseType = CongressTypeEnum.Unknown };
        public bool Equals(CongressType obj) => obj != null && HouseType == obj.HouseType;
        public override int GetHashCode() => HouseType.GetHashCode();
        public override string ToString() => HouseName;

        public static CongressType Parse(string congressTypeString) => congressTypeString.ToLower() switch
        {
            "rep" => Representative,
            "house" => Representative,
            "sen" => Senator,
            "senate" => Senator,
            "joint" => Joint,
            _ => Unknown
        };

        private string HouseName { get; init; }
        private CongressTypeEnum HouseType { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace GovInformer.Models.Common
{
    public sealed record StateTerritory
    {
        private StateTerritory() { }

        private enum PlaceType
        {
            Unknown = 1,
            State = 2,
            Territory = 3,
            District = 4
        };

        private enum StateTerritoryEnum
        {
            UNKNOWN = 1,
            AL = 2,
            AK = 3,
            AR = 4,
            AZ = 5,
            CA = 6,
            CO = 7,
            CT = 8,
            DE = 9,
            FL = 10,
            GA = 11,
            HI = 12,
            IA = 13,
            ID = 14,
            IL = 15,
            IN = 16,
            KS = 17,
            KY = 18,
            LA = 19,
            MA = 20,
            MD = 21,
            ME = 22,
            MI = 23,
            MN = 24,
            MO = 25,
            MS = 26,
            MT = 27,
            NC = 28,
            ND = 29,
            NE = 30,
            NH = 31,
            NJ = 32,
            NM = 33,
            NV = 34,
            NY = 35,
            OK = 36,
            OH = 37,
            OR = 38,
            PA = 39,
            RI = 40,
            SC = 41,
            SD = 42,
            TN = 43,
            TX = 44,
            UT = 45,
            VA = 46,
            VT = 47,
            WA = 48,
            WI = 49,
            WV = 50,
            WY = 51,
            PR = 52,
            AS = 53,
            GU = 54,
            MP = 55,
            VI = 56,
            DC = 57,
        };

        public static StateTerritory Unknown => new StateTerritory { Place = StateTerritoryEnum.UNKNOWN, PlaceName = "UNKNOWN", Type = PlaceType.Unknown };
        public static StateTerritory Alabama => new StateTerritory { Place = StateTerritoryEnum.AL, PlaceName = "Alabama", Type = PlaceType.State };
        public static StateTerritory Alaska => new StateTerritory { Place = StateTerritoryEnum.AK, PlaceName = "Alaska", Type = PlaceType.State };
        public static StateTerritory Arkansas => new StateTerritory { Place = StateTerritoryEnum.AR, PlaceName = "Arkansas", Type = PlaceType.State };
        public static StateTerritory Arizona => new StateTerritory { Place = StateTerritoryEnum.AZ, PlaceName = "Arizona", Type = PlaceType.State };
        public static StateTerritory California => new StateTerritory { Place = StateTerritoryEnum.CA, PlaceName = "California", Type = PlaceType.State };
        public static StateTerritory Colorado => new StateTerritory { Place = StateTerritoryEnum.CO, PlaceName = "Colorado", Type = PlaceType.State };
        public static StateTerritory Connecticut => new StateTerritory { Place = StateTerritoryEnum.CT, PlaceName = "Connecticut", Type = PlaceType.State };
        public static StateTerritory Delaware => new StateTerritory { Place = StateTerritoryEnum.DE, PlaceName = "Delaware", Type = PlaceType.State };
        public static StateTerritory Florida => new StateTerritory { Place = StateTerritoryEnum.FL, PlaceName = "Florida", Type = PlaceType.State };
        public static StateTerritory Georgia => new StateTerritory { Place = StateTerritoryEnum.GA, PlaceName = "Georgia", Type = PlaceType.State };
        public static StateTerritory Hawaii => new StateTerritory { Place = StateTerritoryEnum.HI, PlaceName = "Hawaii", Type = PlaceType.State };
        public static StateTerritory Iowa => new StateTerritory { Place = StateTerritoryEnum.IA, PlaceName = "Iowa", Type = PlaceType.State };
        public static StateTerritory Idaho => new StateTerritory { Place = StateTerritoryEnum.ID, PlaceName = "Idaho", Type = PlaceType.State };
        public static StateTerritory Illinois => new StateTerritory { Place = StateTerritoryEnum.IL, PlaceName = "Illinois", Type = PlaceType.State };
        public static StateTerritory Indiana => new StateTerritory { Place = StateTerritoryEnum.IN, PlaceName = "Indiana", Type = PlaceType.State };
        public static StateTerritory Kansas => new StateTerritory { Place = StateTerritoryEnum.KS, PlaceName = "Kansas", Type = PlaceType.State };
        public static StateTerritory Kentucky => new StateTerritory { Place = StateTerritoryEnum.KY, PlaceName = "Kentucky", Type = PlaceType.State };
        public static StateTerritory Louisiana => new StateTerritory { Place = StateTerritoryEnum.LA, PlaceName = "Louisiana", Type = PlaceType.State };
        public static StateTerritory Massachusetts => new StateTerritory { Place = StateTerritoryEnum.MA, PlaceName = "Massachusetts", Type = PlaceType.State };
        public static StateTerritory Maryland => new StateTerritory { Place = StateTerritoryEnum.MD, PlaceName = "Maryland", Type = PlaceType.State };
        public static StateTerritory Maine => new StateTerritory { Place = StateTerritoryEnum.ME, PlaceName = "Maine", Type = PlaceType.State };
        public static StateTerritory Michigan => new StateTerritory { Place = StateTerritoryEnum.MI, PlaceName = "Michigan", Type = PlaceType.State };
        public static StateTerritory Minnesota => new StateTerritory { Place = StateTerritoryEnum.MN, PlaceName = "Minnesota", Type = PlaceType.State };
        public static StateTerritory Missouri => new StateTerritory { Place = StateTerritoryEnum.MO, PlaceName = "Missouri", Type = PlaceType.State };
        public static StateTerritory Mississippi => new StateTerritory { Place = StateTerritoryEnum.MS, PlaceName = "Mississippi", Type = PlaceType.State };
        public static StateTerritory Montana => new StateTerritory { Place = StateTerritoryEnum.MT, PlaceName = "Montana", Type = PlaceType.State };
        public static StateTerritory NorthCarolina => new StateTerritory { Place = StateTerritoryEnum.NC, PlaceName = "North Carolina", Type = PlaceType.State };
        public static StateTerritory NorthDakota => new StateTerritory { Place = StateTerritoryEnum.ND, PlaceName = "North Dakota", Type = PlaceType.State };
        public static StateTerritory Nebraska => new StateTerritory { Place = StateTerritoryEnum.NE, PlaceName = "Nebraska", Type = PlaceType.State };
        public static StateTerritory NewHampshire => new StateTerritory { Place = StateTerritoryEnum.NH, PlaceName = "New Hampshire", Type = PlaceType.State };
        public static StateTerritory NewJersey => new StateTerritory { Place = StateTerritoryEnum.NJ, PlaceName = "New Jersey", Type = PlaceType.State };
        public static StateTerritory NewMexico => new StateTerritory { Place = StateTerritoryEnum.NM, PlaceName = "New Mexico", Type = PlaceType.State };
        public static StateTerritory Nevada => new StateTerritory { Place = StateTerritoryEnum.NV, PlaceName = "Nevada", Type = PlaceType.State };
        public static StateTerritory NewYork => new StateTerritory { Place = StateTerritoryEnum.NY, PlaceName = "New York", Type = PlaceType.State };
        public static StateTerritory Oklahoma => new StateTerritory { Place = StateTerritoryEnum.OK, PlaceName = "Oklahoma", Type = PlaceType.State };
        public static StateTerritory Ohio => new StateTerritory { Place = StateTerritoryEnum.OH, PlaceName = "Ohio", Type = PlaceType.State };
        public static StateTerritory Oregon => new StateTerritory { Place = StateTerritoryEnum.OR, PlaceName = "Oregon", Type = PlaceType.State };
        public static StateTerritory Pennsylvania => new StateTerritory { Place = StateTerritoryEnum.PA, PlaceName = "Pennsylvania", Type = PlaceType.State };
        public static StateTerritory RhodeIsland => new StateTerritory { Place = StateTerritoryEnum.RI, PlaceName = "Rhode Island", Type = PlaceType.State };
        public static StateTerritory SouthCarolina => new StateTerritory { Place = StateTerritoryEnum.SC, PlaceName = "South Carolina", Type = PlaceType.State };
        public static StateTerritory SouthDakota => new StateTerritory { Place = StateTerritoryEnum.SD, PlaceName = "South Dakota", Type = PlaceType.State };
        public static StateTerritory Tennessee => new StateTerritory { Place = StateTerritoryEnum.TN, PlaceName = "Tennessee", Type = PlaceType.State };
        public static StateTerritory Texas => new StateTerritory { Place = StateTerritoryEnum.TX, PlaceName = "Texas", Type = PlaceType.State };
        public static StateTerritory Utah => new StateTerritory { Place = StateTerritoryEnum.UT, PlaceName = "Utah", Type = PlaceType.State };
        public static StateTerritory Virginia => new StateTerritory { Place = StateTerritoryEnum.VA, PlaceName = "Virginia", Type = PlaceType.State };
        public static StateTerritory Vermont => new StateTerritory { Place = StateTerritoryEnum.VT, PlaceName = "Vermont", Type = PlaceType.State };
        public static StateTerritory Washington => new StateTerritory { Place = StateTerritoryEnum.WA, PlaceName = "Washington", Type = PlaceType.State };
        public static StateTerritory Wisconsin => new StateTerritory { Place = StateTerritoryEnum.WI, PlaceName = "Wisconsin", Type = PlaceType.State };
        public static StateTerritory WestVirginia => new StateTerritory { Place = StateTerritoryEnum.WV, PlaceName = "West Virginia", Type = PlaceType.State };
        public static StateTerritory Wyoming => new StateTerritory { Place = StateTerritoryEnum.WY, PlaceName = "Wyoming", Type = PlaceType.State };

        public static StateTerritory PuertoRico => new StateTerritory { Place = StateTerritoryEnum.PR, PlaceName = "Puerto Rico", Type = PlaceType.Territory };
        public static StateTerritory AmericanSamoa => new StateTerritory { Place = StateTerritoryEnum.AS, PlaceName = "American Samoa", Type = PlaceType.Territory };
        public static StateTerritory Guam => new StateTerritory { Place = StateTerritoryEnum.GU, PlaceName = "Guam", Type = PlaceType.Territory };
        public static StateTerritory NorthernMarianaIslands => new StateTerritory { Place = StateTerritoryEnum.MP, PlaceName = "Northern Mariana Islands", Type = PlaceType.Territory };
        public static StateTerritory VirginIslands => new StateTerritory { Place = StateTerritoryEnum.VI, PlaceName = "Virgin Islands", Type = PlaceType.Territory };

        public static StateTerritory DistrictOfColumbia => new StateTerritory { Place = StateTerritoryEnum.DC, PlaceName = "District Of Columbia", Type = PlaceType.District };

        public bool Equals(StateTerritory obj) => obj != null && Place == obj.Place && Type == obj.Type;
        public override int GetHashCode() => Place.GetHashCode();
        public override string ToString() => PlaceName;

        public static StateTerritory Parse(string placeLetters)
        {
            if (placeLetters.Length != 2)
            {
                return Unknown;
            }

            var type = typeof(StateTerritory);
            var staticMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var method in staticMethods)
            {
                if (method.ReturnType == typeof(StateTerritory))
                {
                    var place = (StateTerritory)method.Invoke(null, null);
                    if (Enum.GetName(typeof(StateTerritoryEnum), place.Place) == placeLetters)
                    {
                        return place;
                    }
                }
            }

            return Unknown;
        }

        private StateTerritoryEnum Place { get; init; }
        private PlaceType Type { get; init; }
        private string PlaceName { get; init; }
    }
}

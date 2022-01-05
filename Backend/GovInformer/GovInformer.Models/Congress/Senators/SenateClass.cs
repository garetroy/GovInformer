namespace GovInformer.Models.Congress.Senators
{
    public sealed record SenateClass
    {
        private SenateClass() { }

        private enum SenateClassEnum
        {
            Unknown = 1,
            FirstClass = 2,
            SecondClass = 3,
            ThirdClass = 3,
        };

        public static SenateClass FirstClass => new SenateClass { ClassName = "First Class", ClassType = SenateClassEnum.FirstClass };
        public static SenateClass SecondClass => new SenateClass { ClassName = "Second Class", ClassType = SenateClassEnum.SecondClass };
        public static SenateClass ThirdClass => new SenateClass { ClassName = "Third Class", ClassType = SenateClassEnum.ThirdClass };
        public static SenateClass Unknown => new SenateClass { ClassName = "Unknown", ClassType = SenateClassEnum.Unknown };

        public bool Equals(SenateClass obj) => obj != null && ClassType == obj.ClassType;
        public override int GetHashCode() => ClassType.GetHashCode();
        public override string ToString() => ClassName;

        public static SenateClass Parse(int classType) => classType switch
        {
            1 => FirstClass,
            2 => SecondClass,
            3 => ThirdClass,
            _ => Unknown
        };

        private string ClassName { get; init; }
        private SenateClassEnum ClassType { get; init; }
    }
}

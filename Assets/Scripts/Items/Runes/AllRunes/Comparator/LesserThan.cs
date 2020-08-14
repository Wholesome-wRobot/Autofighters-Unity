using System;

namespace AutoFighters
{
    [Serializable]
    public class LesserThan : Rune
    {
        public override string DisplayName => "Lesser Than Rune";
        public override RuneId RuneId => RuneId.LesserThan;
        public override RuneType RuneType => RuneType.Comparator;
    }
}
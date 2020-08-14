using System;

namespace AutoFighters
{
    [Serializable]
    public class GreaterThan : Rune
    {
        public override string DisplayName => "Greater Than Rune";
        public override RuneId RuneId => RuneId.GreaterThan;
        public override RuneType RuneType => RuneType.Comparator;
    }
}
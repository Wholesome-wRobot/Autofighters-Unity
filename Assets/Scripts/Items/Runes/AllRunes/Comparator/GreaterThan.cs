using System;

namespace AutoFighters
{
    [Serializable]
    public class GreaterThan : Item, IRune
    {
        public RuneId RuneId => RuneId.GreaterThan;
        public RuneType RuneType => RuneType.Comparator;

        public GreaterThan()
        {
            DisplayName = "Greater Than Rune";
        }
    }
}
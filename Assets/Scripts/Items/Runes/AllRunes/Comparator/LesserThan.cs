using System;

namespace AutoFighters
{
    [Serializable]
    public class LesserThan : Item, IRune
    {
        public RuneId RuneId => RuneId.LesserThan;
        public RuneType RuneType => RuneType.Comparator;

        public LesserThan()
        {
            DisplayName = "Lesser Than Rune";
        }
    }
}
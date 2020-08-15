using System;

namespace AutoFighters
{
    [Serializable]
    public class FiftyPercent : Item, IRune
    {
        public RuneId RuneId => RuneId.FiftyPercent;
        public RuneType RuneType => RuneType.PercentValue;

        public FiftyPercent()
        {
            DisplayName = "50% Rune";
        }
    }
}
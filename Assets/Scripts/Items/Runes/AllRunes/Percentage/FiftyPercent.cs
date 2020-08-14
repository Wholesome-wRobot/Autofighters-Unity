using System;

namespace AutoFighters
{
    [Serializable]
    public class FiftyPercent : Rune
    {
        public override string DisplayName => "50% Rune";
        public override RuneId RuneId => RuneId.FiftyPercent;
        public override RuneType RuneType => RuneType.PercentValue;
    }
}
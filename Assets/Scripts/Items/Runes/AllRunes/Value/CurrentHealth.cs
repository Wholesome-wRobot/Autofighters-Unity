using System;

namespace AutoFighters
{
    [Serializable]
    public class CurrentHealth : Rune
    {
        public override string DisplayName => "Current Health Rune";
        public override RuneId RuneId => RuneId.CurrentHealth;
        public override RuneType RuneType => RuneType.NumberValue;
    }
}
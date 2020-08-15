using System;

namespace AutoFighters
{
    [Serializable]
    public class CurrentHealth : Item, IRune
    {
        public RuneId RuneId => RuneId.CurrentHealth;
        public RuneType RuneType => RuneType.NumberValue;

        public CurrentHealth()
        {
            DisplayName = "Current Health Rune";
        }
    }
}
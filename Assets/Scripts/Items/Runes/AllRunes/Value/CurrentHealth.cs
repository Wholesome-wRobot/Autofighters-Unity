namespace AutoFighters
{
    public class CurrentHealth : Rune
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "Current Health Rune";
        public override RuneId RuneId => RuneId.CurrentHealth;
        public override RuneType RuneType => RuneType.NumberValue;
    }
}
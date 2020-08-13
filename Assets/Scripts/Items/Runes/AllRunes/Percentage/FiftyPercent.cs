namespace AutoFighters
{
    public class FiftyPercent : Rune
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "50% Rune";
        public override RuneId RuneId => RuneId.FiftyPercent;
        public override RuneType RuneType => RuneType.PercentValue;
    }
}
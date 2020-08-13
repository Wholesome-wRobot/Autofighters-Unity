namespace AutoFighters
{
    public class GreaterThan : Rune
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "Greater Than Rune";
        public override RuneId RuneId => RuneId.GreaterThan;
        public override RuneType RuneType => RuneType.Comparator;
    }
}
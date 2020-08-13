namespace AutoFighters
{
    public class LesserThan : Rune
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "Lesser Than Rune";
        public override RuneId RuneId => RuneId.LesserThan;
        public override RuneType RuneType => RuneType.Comparator;
    }
}
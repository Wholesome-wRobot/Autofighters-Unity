
namespace AutoFighters
{
    public abstract class Rune : Item
    {
        public abstract RuneId RuneId { get; }
        public abstract RuneType RuneType { get; }
    }

    public enum RuneType
    {
        Comparator,
        NumberValue,
        PercentValue,
        Buff
    }

    public enum RuneId
    {
        None,
        GreaterThan,
        LesserThan,
        CurrentHealth,
        CurrentMana,
        CurrentEnergy,
        ZeroPercent,
        TwentyFivePercent,
        FiftyPercent,
        SeventyFivePercent,
        HundredPercent
    }
}
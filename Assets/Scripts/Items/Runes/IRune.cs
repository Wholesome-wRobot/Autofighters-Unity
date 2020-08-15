namespace AutoFighters
{
    public interface IRune
    {
        string DisplayName { get; }
        RuneType RuneType { get; }
    }
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
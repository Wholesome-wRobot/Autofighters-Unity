using System;

namespace AutoFighters
{
    [Serializable]
    public class Rune : Item
    {
    }
}

public enum RuneType
{
    Comparator,
    NumberValue,
    PercentValue,
    Buff
}
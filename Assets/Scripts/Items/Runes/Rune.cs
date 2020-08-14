using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public abstract class Rune : Item
    {
        [SerializeField]
        private RuneId _runeId;

        public abstract RuneId RuneId { get; }
        public abstract RuneType RuneType { get; }

        public Rune()
        {
            _runeId = RuneId;
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
}
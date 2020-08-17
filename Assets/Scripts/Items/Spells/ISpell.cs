using UnityEngine.UI;

public enum SpellId
{
    None,
    BasicAttack,
    BasicHeal
}

namespace AutoFighters
{
    public interface ISpell
    {
        string DisplayName { get; }
        SpellId SpellID { get; }
        int Damage { get; }
        int Heal { get; }
        TargetFaction DefaultTargetFaction { get; }
        int TargetAmount { get; }
        AnimationTrigger CastAnimationTrigger { get; }
        int ManaCost { get; }

        bool ReadyForImpact(SpellInstance spellInstance);
    }
}

public abstract class Spell
{    
    public abstract SpellID SpellID { get; }
    public abstract string DisplayName { get; }
    public abstract int Damage { get; }
    public abstract int Heal { get; }
    public abstract TargetFaction DefaultTargetFaction { get; }
    public abstract int TargetAmount { get; }
    public abstract AnimationTrigger CastAnimationTrigger { get; }

    public abstract bool ReadyForImpact(SpellInstance spellInstance);
}

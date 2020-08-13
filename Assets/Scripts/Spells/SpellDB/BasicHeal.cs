public class BasicHeal : Spell
{
    public override string DisplayName => "Basic Heal";
    public override SpellID SpellID => SpellID.BasicHeal;
    public override int Damage => 0;
    public override int Heal => 50;
    public override TargetFaction DefaultTargetFaction => TargetFaction.Same;
    public override int TargetAmount => 2;
    public override AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;

    public override bool ReadyForImpact(SpellInstance spellInstance)
    {
        return true;
    }
}

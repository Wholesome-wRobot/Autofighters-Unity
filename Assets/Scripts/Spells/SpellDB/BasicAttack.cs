public class BasicAttack : Spell
{
    public override string DisplayName => "Basic Attack";
    public override SpellID SpellID => SpellID.BasicAttack;
    public override int Damage => 50;
    public override int Heal => 0;
    public override TargetFaction DefaultTargetFaction => TargetFaction.Opposite;
    public override int TargetAmount => 1;
    public override AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;

    public override bool ReadyForImpact(SpellInstance spellInstance)
    {
        return true;
    }
}

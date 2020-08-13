using System;
namespace AutoFighters
{
    public class BasicAttack : Spell
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "Basic Attack";
        public override SpellId SpellID => SpellId.BasicAttack;
        public override int Damage => 50;
        public override int Heal => 0;
        public override TargetFaction DefaultTargetFaction => TargetFaction.Opposite;
        public override int TargetAmount => 1;
        public override AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;
        public override int ManaCost => 0;

        // Return true when the spell is ready for impact (after an animation, for example)
        public override bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }
    }
}

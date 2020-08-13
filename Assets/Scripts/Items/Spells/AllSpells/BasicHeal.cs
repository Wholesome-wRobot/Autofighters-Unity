﻿using System;
namespace AutoFighters
{
    public class BasicHeal : Spell
    {
        public override ulong UniqueId => MainController.Instance.GenerateUniqueID();
        public override string DisplayName => "Basic Heal";
        public override SpellId SpellID => SpellId.BasicHeal;
        public override int Damage => 0;
        public override int Heal => 50;
        public override TargetFaction DefaultTargetFaction => TargetFaction.Same;
        public override int TargetAmount => 2;
        public override AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;
        public override int ManaCost => 20;

        // Return true when the spell is ready for impact (after an animation, for example)
        public override bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }
    }
}

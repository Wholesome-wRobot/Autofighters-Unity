using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class BasicHeal : Item, ISpell
    {
        public SpellId SpellID => SpellId.BasicHeal;
        public int Damage => 0;
        public int Heal => 50;
        public TargetFaction DefaultTargetFaction => TargetFaction.Same;
        public int TargetAmount => 2;
        public AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;
        public int ManaCost => 20;

        public BasicHeal()
        {
            DisplayName = "Basic Heal";
        }

        public bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }
    }
}

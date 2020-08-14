using System;
using TMPro;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class BasicAttack : Spell
    {
        [SerializeField]
        private string test = "test";

        public override string DisplayName => "Basic Attack";
        public override SpellId SpellID => SpellId.BasicAttack;
        public override int Damage => 50;
        public override int Heal => 0;
        public override TargetFaction DefaultTargetFaction => TargetFaction.Opposite;
        public override int TargetAmount => 1;
        public override AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;
        public override int ManaCost => 0;

        public override bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }
    }
}

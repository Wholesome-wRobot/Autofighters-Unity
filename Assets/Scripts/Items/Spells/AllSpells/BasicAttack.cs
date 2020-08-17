using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class BasicAttack : Item, ISpell
    {
        public SpellId SpellID => SpellId.BasicAttack;
        public int Damage => 50;
        public int Heal => 0;
        public TargetFaction DefaultTargetFaction => TargetFaction.Opposite;
        public int TargetAmount => 1;
        public AnimationTrigger CastAnimationTrigger => AnimationTrigger.Attack;
        public int ManaCost => 0;


        public BasicAttack()
        {
            DisplayName = "Basic Attack";
            //UniqueId = MainController.Instance.GenerateUniqueID();
        }
        
        public bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }
    }
}

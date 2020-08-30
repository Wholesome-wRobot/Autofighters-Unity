using System;
using System.Collections.Generic;

namespace AutoFighters
{
    [Serializable]
    public class Spell : Item
    {
        public int Damage;
        public int Heal;
        public TargetFaction DefaultTargetFaction; 
        public int TargetAmount;
        public AnimationTrigger CastAnimationTrigger;
        public int ManaCost;
        public List<Rune> RuneList = new List<Rune>();

        public bool ReadyForImpact(SpellInstance spellInstance)
        {
            return true;
        }

        public void AddRune(Rune rune)
        {
            RuneList.Add(rune);
        }
    }
}

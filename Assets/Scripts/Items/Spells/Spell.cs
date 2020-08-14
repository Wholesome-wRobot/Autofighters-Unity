using UnityEngine;

namespace AutoFighters
{
    public enum SpellId
    {
        None,
        BasicAttack,
        BasicHeal
    }

    public abstract class Spell : Item
    {
        [SerializeField]
        private SpellId _spellId;

        public abstract SpellId SpellID { get; }
        public abstract int Damage { get; }
        public abstract int Heal { get; }
        public abstract TargetFaction DefaultTargetFaction { get; }
        public abstract int TargetAmount { get; }
        public abstract AnimationTrigger CastAnimationTrigger { get; }
        public abstract int ManaCost { get; }

        // Returns true when the spell is ready for impact (after an animation, for example)
        public abstract bool ReadyForImpact(SpellInstance spellInstance);

        public Spell()
        {
            _spellId = SpellID;
        }
    }
}

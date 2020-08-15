using UnityEngine;

namespace AutoFighters
{
    public class SpellInstance : MonoBehaviour
    {
        public ISpell Spell { get; private set; }
        public Character Caster { get; private set; }
        public Character Target { get; private set; }

        void Update()
        {
            if (Spell.ReadyForImpact(this))
            {
                SpellEffect.Apply(this);
                Destroy(gameObject);
            }
        }

        public void SetSpell(ISpell spell) { Spell = spell; }
        public void SetCaster(Character caster) { Caster = caster; }
        public void SetTarget(Character target) { Target = target; }
    }
}
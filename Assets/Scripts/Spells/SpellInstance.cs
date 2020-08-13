using UnityEngine;

public class SpellInstance : MonoBehaviour
{
    [SerializeField]
    private string spellName; // just to show in editor

    public Spell Spell { get; private set; }
    public Character Caster { get; private set; }
    public Character Target { get; private set; }

    void Start()
    {
        spellName = Spell.DisplayName;
    }

    void Update()
    {
        if (Spell.ReadyForImpact(this))
        {
            SpellEffect.Apply(this);
            Destroy(gameObject);
        }
    }

    public void SetSpell(Spell spell) { Spell = spell; }
    public void SetCaster(Character caster) { Caster = caster; }
    public void SetTarget(Character target) { Target = target; }
}

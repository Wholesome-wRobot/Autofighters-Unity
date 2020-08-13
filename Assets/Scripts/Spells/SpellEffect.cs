public static class SpellEffect
{
    public static void Apply(SpellInstance spellInstance)
    {
        // Damage
        if (spellInstance.Spell.Damage > 0)
        {
            spellInstance.Target.ReceiveDamage(spellInstance.Spell.Damage);
        }

        // Heal
        if (spellInstance.Spell.Heal > 0)
        {
            spellInstance.Target.ReceiveHeal(spellInstance.Spell.Heal);
        }
    }
}

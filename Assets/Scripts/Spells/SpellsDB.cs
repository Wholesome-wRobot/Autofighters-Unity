using System.Collections.Generic;

public enum SpellID
{
    None,
    BasicAttack,
    BasicHeal
}

public static class SpellsDB
{

    static SpellsDB()
    {
        None.Id = SpellID.None;
        None.DisplayName = "None";
         
        // BASIC SPELLS
        BasicAttack.Id = SpellID.BasicAttack;
        BasicAttack.DisplayName = "Basic Attack";
        BasicAttack.DefaultTargetFaction = TargetFaction.Opposite;
        BasicAttack.Damage = 50;

        BasicHeal.Id = SpellID.BasicHeal;
        BasicHeal.DisplayName = "Basic Heal";
        BasicHeal.DefaultTargetFaction = TargetFaction.Same;
        BasicHeal.TargetAmount = 2;
        BasicHeal.Heal = 40;
    }

    public static Spell GetSpellById(SpellID id)
    {
        return AllSpells.Find(i => i.Id == id);
    }
}

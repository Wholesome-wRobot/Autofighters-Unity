using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoFighters
{
    public static class SpellsDB
    {/*
    private static Dictionary<SpellID, Spell> SpellDictionary { get; set; }

    public static void Initialize()
    {
        SpellDictionary = new Dictionary<SpellID, Spell>();

        var allSpellTypes = Assembly.GetAssembly(typeof(Spell)).GetTypes().Where(t => typeof(Spell).IsAssignableFrom(t) && t.IsAbstract == false);

        // Fill the dictionary with instance of spells
        foreach (var spellType in allSpellTypes)
        {
            Spell spell = Activator.CreateInstance(spellType) as Spell;
            SpellDictionary.Add(spell.SpellID, spell);
        }
    }

    public static Spell Get(SpellID id)
    {
        return SpellDictionary[id];
    }*/
    }
}

using System.Collections.Generic;

public interface Spell
{    
    public SpellID Id { get; set; }
    public string DisplayName { get; set; }
    public int Damage { get; set; }
    public int Heal { get; set; }
    public TargetFaction DefaultTargetFaction { get; set; }

    // Instantiateur
    public Spell()
    {
        DefaultTargetFaction = TargetFaction.Any;
    }

    public abstract void Use(List<Character> listTargets, Character user);
}

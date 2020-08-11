using System.Collections.Generic;

[System.Serializable]
public class CharacterStats
{
    // General
    public uint uniqueId;
    public string name;
    public Faction faction;
    public Job job;

    // Position
    public float positionX;
    public float positionY;

    // Energy
    public float currentEnergy = 0f;
    public float maxEnergy = 200f;
    public float energyRate = 0.3f;

    // Health
    public float maxHealth = 400f;
    public float currentHealth = 400f;

    // Mana
    public float currentMana = 150f;
    public float maxMana = 200f;

    // Spells
    public List<SpellID> spellSlots = new List<SpellID>
    {
        SpellID.BasicAttack,
        SpellID.None,
        SpellID.None,
        SpellID.None
    };
}

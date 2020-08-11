using UnityEngine;

public class CharacterSpot : MonoBehaviour
{
    public Faction spotFaction;
    public int id;
    public uint occupiedBy;

    public bool IsOccupied { get { return occupiedBy != 0; } }

    public void AttachCharacter(CharacterStats characterStats)
    {
        spotFaction = characterStats.faction;
        occupiedBy = characterStats.uniqueId;
    }

    public void DetachCharacter()
    {
        spotFaction = Faction.None;
        occupiedBy = 0;
    }
}

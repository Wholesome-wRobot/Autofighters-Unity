using UnityEngine;

namespace AutoFighters
{
    public class CharacterSpot : MonoBehaviour
    {
        public Faction spotFaction;
        public int id;
        public ulong occupiedBy;

        public bool IsOccupied { get { return occupiedBy != 0; } }

        void Awake()
        {
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = null;
        }

        public void AttachCharacter(CharacterStats characterStats)
        {
            spotFaction = characterStats.Faction;
            occupiedBy = characterStats.UniqueId;
        }

        public void DetachCharacter()
        {
            spotFaction = Faction.None;
            occupiedBy = 0;
        }
    }
}

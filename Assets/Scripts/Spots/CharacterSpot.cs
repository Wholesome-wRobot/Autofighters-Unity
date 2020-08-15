using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoFighters
{
    public class CharacterSpot : MonoBehaviour
    {
        [SerializeField] private Faction _spotFaction;
        public Faction SpotFaction { get => _spotFaction; private set => _spotFaction = value; }

        [SerializeField]  private int _spotId;
        public int SpotId { get => _spotId; private set => _spotId = value; }

        [SerializeField] private ulong _occupiedBy;
        public ulong OccupiedBy { get => _occupiedBy; private set => _occupiedBy = value; }


        void Awake()
        {
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = null;
        }

        public void AttachCharacter(CharacterStats characterStats)
        {
            SpotFaction = characterStats.Faction;
            OccupiedBy = characterStats.UniqueId;
        }

        public void DetachCharacter()
        {
            OccupiedBy = 0;
        }

        public static CharacterSpot GetFirstAvailableSpot(Faction faction)
        {
            List<CharacterSpot> allSpots = FindObjectsOfType<CharacterSpot>().OrderBy(o => o.SpotId).ToList();

            foreach (CharacterSpot spot in allSpots)
            {
                if (spot.SpotFaction == faction && spot.OccupiedBy == 0)
                    return spot;
            }
            return null;
        }
    }
}

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

        [SerializeField] private bool _occupied;
        public bool Occupied { get => _occupied; private set => _occupied = value; }


        void Awake()
        {
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = null;
        }

        public CharacterSpot AttachCharacter(Character character)
        {
            SpotFaction = character.Stats.Faction;
            Occupied = true;
            return this;
        }

        public void DetachCharacter()
        {
            Occupied = false;
        }

        public static CharacterSpot GetFirstAvailableSpot(Faction faction)
        {
            List<CharacterSpot> allSpots = FindObjectsOfType<CharacterSpot>().OrderBy(o => o.SpotId).ToList();

            foreach (CharacterSpot spot in allSpots)
            {
                if (spot.SpotFaction == faction && !spot.Occupied)
                    return spot;
            }
            return null;
        }
    }
}

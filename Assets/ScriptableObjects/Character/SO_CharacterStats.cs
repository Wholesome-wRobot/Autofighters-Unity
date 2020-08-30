using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "DefaultCharacterStats", menuName = "CharacterStats")]
    public class SO_CharacterStats : ScriptableObject
    {
        [SerializeField] public CharacterArchetype CharacterArchetype;
        [SerializeField] public RuntimeAnimatorController AnimatorController;

        // -------------------- General --------------------

        [SerializeField] public string DisplayName;
        [SerializeField] public Faction Faction;

        // -------------------- Energy --------------------

        [SerializeField] public double CurrentEnergy;
        [SerializeField] public double MaxEnergy;
        [SerializeField] public double EnergyRate;

        // -------------------- Health --------------------

        [SerializeField] public double MaxHealth;
        [SerializeField] public double CurrentHealth;

        // -------------------- Mana --------------------

        [SerializeField] public double CurrentMana;
        [SerializeField] public double MaxMana;

        // -------------------- Spells --------------------

        [SerializeReference] public List<Spell> SpellSlots;

        void OnEnable()
        {
            SpellSlots = new List<Spell>()
            {
                null,
                null,
                null,
                null
            };
        }
    }
}

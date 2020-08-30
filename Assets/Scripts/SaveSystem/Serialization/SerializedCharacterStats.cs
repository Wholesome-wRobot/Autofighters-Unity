using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [System.Serializable]
    public class SerializedCharacterStats
    {
        [SerializeField] private CharacterArchetype _characterArchetype;
        public CharacterArchetype CharacterArchetype { get => _characterArchetype; private set => _characterArchetype = value; }

        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; private set => _displayName = value; }

        [SerializeField] private double _currentEnergy;
        public double CurrentEnergy { get => _currentEnergy; private set => _currentEnergy = value; }

        [SerializeField] private double _currenHealth;
        public double CurrentHealth { get => _currenHealth; private set => _currenHealth = value; }

        [SerializeField] private double _currentMana;
        public double CurrentMana { get => _currentMana; private set => _currentMana = value; }

        [SerializeField] private List<SerializedItem> _spellSlots;
        public List<SerializedItem> SpellSlots { get => _spellSlots; private set => _spellSlots = value; }

        public SerializedCharacterStats(CharacterStats stats)
        {
            CharacterArchetype = stats.CharacterArchetype;
            DisplayName = stats.DisplayName;
            CurrentEnergy = stats.CurrentEnergy;
            CurrentHealth = stats.CurrentHealth;
            CurrentMana = stats.CurrentMana;

            SpellSlots = new List<SerializedItem>();
            foreach (Item item in stats.SpellSlots)
            {
                SpellSlots.Add(new SerializedItem(item));
            }
        }

        public CharacterStats Deserialize()
        {
            CharacterStats stats = new CharacterStats(CharacterArchetype);
            stats.SetDisplayName(DisplayName);
            stats.SetCurrentEnergy(CurrentEnergy);
            stats.SetCurrentHealth(CurrentHealth);
            stats.SetCurrentMana(CurrentMana);

            for (int i = 0; i < SpellSlots.Count; i++)
            {
                stats.EquipSpell(SpellSlots[i].Deserialize() as Spell, i);
            }

            return stats;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class CharacterStats
    {
        // -------------------- General --------------------

        [SerializeField] private ulong _uniqueId;
        public ulong UniqueId { get => _uniqueId; private set => _uniqueId = value; }

        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; private set => _displayName = value; }


        [SerializeField] private Faction _faction;
        public Faction Faction { get => _faction; private set => _faction = value; }

        [SerializeField] private Job _job;
        public Job Job { get => _job; private set => _job = value; }

        // -------------------- Energy --------------------

        [SerializeField] private double _currentEnergy;
        public double CurrentEnergy { get => _currentEnergy; private set => _currentEnergy = value; }

        [SerializeField] private double _maxEnergy;
        public double MaxEnergy { get => _maxEnergy; private set => _maxEnergy = value; }

        [SerializeField] private double _energyRate;
        public double EnergyRate { get => _energyRate; private set => _energyRate = value; }

        // -------------------- Health --------------------

        [SerializeField] private double _maxHealth;
        public double MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

        [SerializeField] private double _currentHealth;
        public double CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }

        // -------------------- Mana --------------------

        [SerializeField] private double _currentMana;
        public double CurrentMana { get => _currentMana; private set => _currentMana = value; }

        [SerializeField] private double _maxMana;
        public double MaxMana { get => _maxMana; private set => _maxMana = value; }

        // -------------------- Spells --------------------

        [SerializeReference] private List<ISpell> _spellSlots;
        public List<ISpell> SpellSlots { get => _spellSlots; private set => _spellSlots = value; }


        public CharacterStats()
        {
            _spellSlots = new List<ISpell>()
            {
                null,
                null,
                null,
                null
            };

            CurrentEnergy = 0;
            MaxEnergy = 100;

            MaxHealth = 200;
            CurrentHealth = MaxHealth;

            MaxMana = 200;
            CurrentMana = 100;

            EnergyRate = 0.1f;
        }

        public void SetCurrentEnergy(double energy) => CurrentEnergy = energy;
        public void TickEnergy() => CurrentEnergy += EnergyRate;
        public void ModifyCurrentHealth(int value)
        {
            CurrentHealth = Math.Min(MaxHealth, Math.Max(CurrentHealth += value, 0));
        }
        public void SetFaction(Faction faction) => Faction = faction;
        public void SetUniqueId(ulong uniqueId) => UniqueId = uniqueId;
        public string SetDisplayName(string displayName) => DisplayName = displayName;
    }
}
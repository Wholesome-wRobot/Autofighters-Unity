using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class CharacterStats
    {
        // -------------------- General --------------------

        [SerializeField]
        private ulong _uniqueId;
        public ulong UniqueId { get { return _uniqueId; } set => _uniqueId = value; }

        [SerializeField]
        private string _displayName;
        public string DisplayName { get { return _displayName; } set => _displayName = value; }

        [SerializeField]
        private Faction _faction;
        public Faction Faction { get { return _faction; } set => _faction = value; }

        [SerializeField]
        private Job _job;
        public Job Job { get { return _job; } set => _job = value; }

        // -------------------- Energy --------------------

        [SerializeField]
        private float _currentEnergy;
        public float CurrentEnergy { get { return _currentEnergy; } set => _currentEnergy = value; }

        [SerializeField]
        private float _maxEnergy;
        public float MaxEnergy { get { return _maxEnergy; } set => _maxEnergy = value; }

        [SerializeField]
        private float _energyRate;
        public float EnergyRate { get { return _energyRate; } set => _energyRate = value; }

        // -------------------- Health --------------------

        [SerializeField]
        private float _maxHealth;
        public float MaxHealth { get { return _maxHealth; } set => _maxHealth = value; }

        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth { get { return _currentHealth; } set => _currentHealth = value; }

        // -------------------- Mana --------------------

        [SerializeField]
        private float _currentMana;
        public float CurrentMana { get { return _currentMana; } set => _currentMana = value; }

        [SerializeField]
        private float _maxMana;
        public float MaxMana { get { return _maxMana; } set => _maxMana = value; }

        // -------------------- Spells --------------------

        [SerializeField]
        private List<Spell> _spellSlots;
        public List<Spell> SpellSlots { get { return _spellSlots; } set => _spellSlots = value; }

        public CharacterStats()
        {
            _spellSlots = new List<Spell>()
            {
                null,
                null,
                null,
                null
            };

            CurrentEnergy = 0;
            MaxEnergy = 100;

            MaxHealth = 400;
            CurrentHealth = MaxHealth;

            MaxMana = 200;
            CurrentMana = 100;

            EnergyRate = 0.1f;
        }
    }
}
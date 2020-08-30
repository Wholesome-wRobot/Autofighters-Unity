using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class CharacterStats
    {
        [SerializeField] private CharacterArchetype _characterArchetype;
        public CharacterArchetype CharacterArchetype { get => _characterArchetype; private set => _characterArchetype = value; }

        [SerializeField] private RuntimeAnimatorController _animatorController;
        public RuntimeAnimatorController AnimatorController { get => _animatorController; private set => _animatorController = value; }

        [SerializeField] private IndividualLowPanel _myLowCharacterPanel;
        public IndividualLowPanel MyLowCharacterPanel { get => _myLowCharacterPanel; private set => _myLowCharacterPanel = value; }

        // -------------------- General --------------------

        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; private set => _displayName = value; }

        [SerializeField] private Faction _faction;
        public Faction Faction { get => _faction; private set => _faction = value; }

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

        [SerializeReference] private List<Spell> _spellSlots;
        public List<Spell> SpellSlots { get => _spellSlots; private set => _spellSlots = value; }

        // Constructor, LOAD STATS FROM SCRIPTABLE OBJECT
        public CharacterStats(CharacterArchetype archetype)
        {
            SO_CharacterStats characterArchetype = Database.GetCharacterSOByArchetype(archetype);

            CharacterArchetype = characterArchetype.CharacterArchetype;
            AnimatorController = characterArchetype.AnimatorController;

            DisplayName = characterArchetype.DisplayName + " " + UnityEngine.Random.Range(0, 1000);
            Faction = characterArchetype.Faction;

            CurrentEnergy = characterArchetype.CurrentEnergy;
            MaxEnergy = characterArchetype.MaxEnergy;
            EnergyRate = characterArchetype.EnergyRate;

            MaxHealth = characterArchetype.MaxHealth;
            CurrentHealth = characterArchetype.CurrentHealth;

            MaxMana = characterArchetype.MaxMana;
            CurrentMana = characterArchetype.CurrentMana;

            SpellSlots = new List<Spell>();
            foreach (Spell spell in characterArchetype.SpellSlots)
                if (spell != null)
                    SpellSlots.Add(ScriptableObject.Instantiate(spell));
                else
                    SpellSlots.Add(null);
        }

        public void SetCurrentEnergy(double energy) => CurrentEnergy = energy;
        public void SetCurrentHealth(double health) => CurrentHealth = health;
        public void SetDisplayName(string displayName) => DisplayName = displayName;
        public double SetCurrentMana(double mana) => CurrentMana = mana;

        public void EquipSpell(Item item, int slot)
        {
            if (item != null)
            {
                SpellSlots[slot] = item as Spell;
                Debug.Log($"{DisplayName} equipped {item.DisplayName} in slot {slot}");
            }
            else
            {
                UnequipSpell(slot);
            }
        }

        public void UnequipSpell(int slot)
        {
            Debug.Log($"{DisplayName} unequipped spell {slot}");
            SpellSlots[slot] = null;
        }

        public void TickEnergy() => CurrentEnergy += EnergyRate;

        public void ModifyCurrentHealth(int value)
        {
            CurrentHealth = Math.Min(MaxHealth, Math.Max(CurrentHealth += value, 0));
        }

        public void SetMyLowCharacterPanel(IndividualLowPanel panel)
        {
            MyLowCharacterPanel = panel;
            MyLowCharacterPanel.SetCharacterName(DisplayName);
        }
    }
}
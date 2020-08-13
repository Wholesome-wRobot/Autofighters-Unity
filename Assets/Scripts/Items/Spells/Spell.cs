using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AutoFighters
{
    public enum SpellId
    {
        None,
        BasicAttack,
        BasicHeal
    }

    [Serializable]
    public abstract class Spell : Item
    {
        [SerializeField]
        private SpellId _spellID;
        [SerializeField]
        private ulong _uniqueId;

        public abstract SpellId SpellID { get; }
        public abstract int Damage { get; }
        public abstract int Heal { get; }
        public abstract TargetFaction DefaultTargetFaction { get; }
        public abstract int TargetAmount { get; }
        public abstract AnimationTrigger CastAnimationTrigger { get; }
        public abstract int ManaCost { get; }

        public Spell()
        {
            _spellID = SpellID;
            _uniqueId = UniqueId;
        }

        public abstract bool ReadyForImpact(SpellInstance spellInstance);

        public void SaveItemToFile(string charSpellFolder)
        {
            Directory.CreateDirectory(charSpellFolder);

            // Save Spell into a unique file
            string destination = $"{charSpellFolder}/{UniqueId}.dat";
            Debug.Log($"Saving spell {DisplayName} to {destination}");
            FileStream file;

            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, this);
            file.Close();
        }
    }
}

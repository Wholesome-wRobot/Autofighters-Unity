using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Item", menuName = "Spell")]
    public class Spell : Item
    {
        [SerializeField] private int _damage;
        public int Damage { get => _damage; private set => _damage = value; }

        [SerializeField] private int _heal;
        public int Heal { get => _heal; private set => _heal = value; }

        [SerializeField] private TargetFaction _defaultTargetFaction;
        public TargetFaction DefaultTargetFaction { get => _defaultTargetFaction; private set => _defaultTargetFaction = value; }

        [SerializeField] private int _targetAmount;
        public int TargetAmount { get => _targetAmount; private set =>  _targetAmount = value; }

        [SerializeField] private AnimationTrigger _castAnimationTrigger;
        public AnimationTrigger CastAnimationTrigger { get => _castAnimationTrigger; private set => _castAnimationTrigger = value; }

        [SerializeField] private int _manaCost;
        public int ManaCost { get => _manaCost; private set => _manaCost = value; }
    }
}

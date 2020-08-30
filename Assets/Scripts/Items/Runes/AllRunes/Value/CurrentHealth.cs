using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Current Health Rune", menuName = "Runes/Current Health Rune")]
    public class CurrentHealth : Rune
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Current Health Rune";
            ItemId = ItemId.CurrentHealth;
        }
    }
}
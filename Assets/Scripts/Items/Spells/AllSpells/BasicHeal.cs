using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "BasicHeal", menuName = "Spells/BasicHeal")]
    public class BasicHeal : Spell
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Basic Heal";
            ItemId = ItemId.BasicHeal; 
        }
    }
}
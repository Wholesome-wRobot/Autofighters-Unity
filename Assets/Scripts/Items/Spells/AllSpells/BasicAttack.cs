using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "BasicAttack", menuName = "Spells/BasicAttack")]
    public class BasicAttack : Spell
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Basic Attack";
            ItemId = ItemId.BasicAttack;
        }
    }
}
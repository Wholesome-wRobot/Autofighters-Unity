using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Greater Than Rune", menuName = "Runes/Greater Than Rune")]
    public class GreaterThan : Rune
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Greater Than Rune";
            ItemId = ItemId.GreaterThan;
        }
    }
}
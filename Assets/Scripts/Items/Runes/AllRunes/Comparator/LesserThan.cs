using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Lesser Than Rune", menuName = "Runes/Lesser Than Rune")]
    public class LesserThan : Rune
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Lesser Than Rune";
            ItemId = ItemId.LesserThan;
        }
    }
}
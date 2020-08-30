using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Fifty Percent Rune", menuName = "Runes/Fifty Percent Rune")]
    public class FiftyPercent : Rune
    {
        public new void OnEnable()
        {
            base.OnEnable();
            DisplayName = "Fifty Percent Rune";
            ItemId = ItemId.FiftyPercent;
        }
    }
}
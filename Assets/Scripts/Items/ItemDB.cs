using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "Other/ItemDatabase")]
    public class ItemDB : ScriptableObject
    {
        [SerializeField] private List<Item> _itemList;
        public List<Item> ItemList { get => _itemList; private set => _itemList = value; }
    }
}

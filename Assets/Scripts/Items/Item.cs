using System;
using UnityEngine;

namespace AutoFighters
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        public Sprite Icon { get => _icon; private set => _icon = value; }

        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; private set => _displayName = value; }

        [SerializeField] private ItemId _itemId;
        public ItemId ItemId { get => _itemId; private set => _itemId = value; }
    }
}
using System;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class Item
    {
        [SerializeField] private ulong _uniqueId;
        public ulong UniqueId { get => _uniqueId; private set => _uniqueId = value; }

        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; set => _displayName = value; }

        public Item()
        { 
            if (_uniqueId == 0L)
                _uniqueId = MainController.Instance.GenerateUniqueID();
        }
    }
}
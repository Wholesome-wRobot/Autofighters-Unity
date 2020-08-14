using System;
using UnityEngine;

namespace AutoFighters
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField]
        private ulong _uniqueId;
        public ulong UniqueId { get { return _uniqueId; } private set { _uniqueId = value; } }

        public abstract string DisplayName { get; }

        public void OnEnable() 
        { 
            hideFlags = HideFlags.HideAndDontSave;
            if (_uniqueId == 0L)
                _uniqueId = MainController.Instance.GenerateUniqueID();
        }
    }
}
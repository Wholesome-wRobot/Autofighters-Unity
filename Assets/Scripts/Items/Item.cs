using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    [Serializable]
    public class Item
    {
        [SerializeField] private string _displayName;
        public string DisplayName { get => _displayName; set => _displayName = value; }
    }
}
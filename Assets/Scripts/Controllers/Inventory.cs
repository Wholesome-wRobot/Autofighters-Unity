using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [Serializable]
    public class Inventory
    {
        [SerializeField] private List<Item> _content;
        public List<Item> Content { get => _content; private set => _content = value; }

        public Inventory()
        {
            Content = new List<Item>();
        }

        public void AddToInventory(Item item)
        {
            Debug.Log($"Adding {item.DisplayName} with id {item.UniqueId} to inventory");
            Content.Add(item); 
        }
    }
}
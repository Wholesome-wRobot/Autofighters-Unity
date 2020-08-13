using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AutoFighters
{
    public class Inventory
    {
        public List<object> Content { get; private set; }

        public Inventory()
        {
            Content = new List<object>();

            AddToInventory(new BasicAttack());
            AddToInventory(new BasicAttack());
            AddToInventory(new BasicHeal());
            AddToInventory(new LesserThan());
            AddToInventory(new CurrentHealth());
            AddToInventory(new FiftyPercent());
        }

        public void AddToInventory(Item item)
        {
            Content.Add(item);
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    [Serializable]
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Item _item;
        public Item Item { get => _listItems[_slotNumber]; }

        private List<Item> _listItems;
        [SerializeField] private int _slotNumber;

        private Image icon;

        void Start()
        {
            Transform transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(1, 1, 1);
            _item = _listItems[_slotNumber];
        }

        public void Initialize (List<Item> listItems, int slotNumber)
        {
            _listItems = listItems;
            _slotNumber = slotNumber;
        }
    }
}

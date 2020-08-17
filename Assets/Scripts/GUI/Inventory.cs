using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    [Serializable]
    public class Inventory : MonoBehaviour, IMenuPanel
    {
        private Canvas _inventoryCanvas;
        public List<Item> _inventoryItems;
        private int _inventorySize = 16;
        public GameObject slotPrefab;
        private GridLayoutGroup _grid;

        void Awake()
        {
            _inventoryCanvas = GetComponentInChildren<Canvas>();
            _grid = GetComponentInChildren<GridLayoutGroup>();
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            _inventoryCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            _inventoryCanvas.worldCamera = Camera.main;

            // Bind Inventory slots to Item list
            _inventoryItems = new List<Item>();
            for (int i = 0; i < _inventorySize; i++)
            {
                _inventoryItems.Add(null);
                GameObject slot = Instantiate(slotPrefab);
                slot.GetComponent<InventorySlot>().Initialize(_inventoryItems, i);
                slot.transform.SetParent(_grid.GetComponent<Transform>());
            }

            AddToInventory(new BasicHeal());
            AddToInventory(new FiftyPercent());
        }

        void Update()
        {
        }

        public bool AddToInventory(Item item)
        {
            Debug.Log($"Adding {item.DisplayName} to inventory");
            int firstAvailableSlot = GetFirstFreeSlot();

            if (firstAvailableSlot == -1)
            {
                Debug.LogWarning($"No room in Inventory");
                return false;
            }

            _inventoryItems[firstAvailableSlot] = item;
            return true;
        }

        public void LoadInventory(List<Item> inventory)
        {
            _inventoryItems.Clear();
            _inventoryItems = inventory;
        }

        private int GetFirstFreeSlot()
        {
            foreach (Item item in _inventoryItems)
            {
                if (item == null)
                    return _inventoryItems.IndexOf(item);
            }
            return -1;
        }

        public void OpenPanel()
        {
            _inventoryCanvas.enabled = true;
        }

        public void ClosePanel()
        {
            _inventoryCanvas.enabled = false;
        }
    }
}
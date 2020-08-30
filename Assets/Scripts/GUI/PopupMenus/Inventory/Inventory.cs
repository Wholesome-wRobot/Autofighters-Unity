using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    [Serializable]
    public class Inventory : MonoBehaviour, IMenuPanel
    {
        public InventoryItemSlot slotPrefab;

        private int _inventorySize = 49;
        private Canvas _inventoryCanvas;
        private GridLayoutGroup _grid;

        [SerializeField] private List<InventoryItemSlot> _inventorySlots;
        public List<InventoryItemSlot> InventorySlots { get => _inventorySlots; private set => _inventorySlots = value; }

        void Awake()
        {
            _inventoryCanvas = GetComponentInChildren<Canvas>();
            _grid = GetComponentInChildren<GridLayoutGroup>();
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            // Bind Inventory slots to Item list
            InventorySlots = new List<InventoryItemSlot>();
            for (int i = 0; i < _inventorySize; i++)
            {
                InventoryItemSlot slot = Instantiate(slotPrefab);
                slot.GetComponent<InventoryItemSlot>().SetItem(null);
                slot.transform.SetParent(_grid.GetComponent<Transform>());
                slot.inventoryCanvas = _inventoryCanvas;
                slot.SetIndex(i);
                InventorySlots.Add(slot);
            }

            AddToInventory(Database.CreateItemSO(ItemId.BasicAttack));
            AddToInventory(Database.CreateItemSO(ItemId.BasicHeal));
            AddToInventory(Database.CreateItemSO(ItemId.GreaterThan));
            AddToInventory(Database.CreateItemSO(ItemId.LesserThan));
            AddToInventory(Database.CreateItemSO(ItemId.CurrentHealth));
            AddToInventory(Database.CreateItemSO(ItemId.CurrentHealth));

            Spell fSpell = (Spell)InventorySlots[0].Item;
            fSpell.AddRune(Database.CreateItemSO(ItemId.GreaterThan) as Rune);
            fSpell.AddRune(Database.CreateItemSO(ItemId.CurrentHealth) as Rune);
            fSpell.AddRune(Database.CreateItemSO(ItemId.LesserThan) as Rune);
        }

        public bool AddToInventory(Item iteminstance)
        {
            InventoryItemSlot firstAvailableSlot = GetFirstFreeSlot();

            if (firstAvailableSlot == null)
            {
                Debug.LogWarning($"No room in Inventory");
                return false;
            }

            firstAvailableSlot.SetItem(iteminstance);
            return true;
        }

        public void LoadInventory(List<SerializedItem> serializedItemList)
        {
            ClearInventory();

            // Insert every serialized item at the right place in the inventory
            for (int i = 0; i < serializedItemList.Count; i++)
            {
                if (serializedItemList[i] != null)
                    InventorySlots[i].SetItem(serializedItemList[i].Deserialize());
            }
        }

        private void ClearInventory()
        {
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                RemoveItemFromSlot(i);
            }
        }

        private void RemoveItemFromSlot(int slotId)
        {
            InventorySlots[slotId].SetItem(null);
        }

        private InventoryItemSlot GetFirstFreeSlot()
        {
            foreach (InventoryItemSlot slot in InventorySlots)
            {
                if (slot.Item == null)
                    return slot;
            }
            return null;
        }

        public void OpenPanel()
        {
            _inventoryCanvas.enabled = true;
            foreach (Canvas canvas in GetComponentsInChildren<Canvas>())
                canvas.enabled = true;
        }

        public void ClosePanel()
        {
            _inventoryCanvas.enabled = false;
            foreach (Canvas canvas in GetComponentsInChildren<Canvas>())
                canvas.enabled = false;
        }
    }
}
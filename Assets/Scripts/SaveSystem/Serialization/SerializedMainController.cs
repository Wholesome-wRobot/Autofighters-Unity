using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    [System.Serializable]
    public class SerializedMainController
    {
        [SerializeField] private GameState _gameState;
        public GameState GameState { get => _gameState; private set => _gameState = value; }

        [SerializeField] private List<SerializedCharacterStats> _serializedCharacterList;
        public List<SerializedCharacterStats> SerializedCharacterList { get => _serializedCharacterList; private set => _serializedCharacterList = value; }

        [SerializeField] private List<SerializedItem> _serializedInventory;
        public List<SerializedItem> SerializedInventory { get => _serializedInventory; private set => _serializedInventory = value; }

        public SerializedMainController(MainController mainController)
        {
            GameState = mainController.GameState;

            // Inventory
            SerializedInventory = new List<SerializedItem>();
            foreach (InventoryItemSlot slot in mainController.InventoryManager.InventorySlots)
            {
                if (slot.Item != null)
                    SerializedInventory.Add(new SerializedItem(slot.Item));
                else
                    SerializedInventory.Add(null);
            }

            // Character List
            SerializedCharacterList = new List<SerializedCharacterStats>();
            foreach (CharacterStats stats in mainController.CharacterManager.CharacterList)
            {
                SerializedCharacterList.Add(new SerializedCharacterStats(stats));
            }
        }
    }
}

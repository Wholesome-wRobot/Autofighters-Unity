using System.Collections.Generic;

namespace AutoFighters
{
    [System.Serializable]
    public class MainControllerData
    {
        public GameState gameState;
        public ulong currentAvailableUniqueId;
        public List<CharacterStats> characterList;
        public List<Item> inventory;

        public MainControllerData(MainController mainController)
        {
            gameState = mainController.GameState;
            //currentAvailableUniqueId = mainController.CurrentAvailableUniqueId;
            characterList = mainController.CharacterManager.CharacterList;
            inventory = mainController.InventoryManager._inventoryItems;
        }
    }
}

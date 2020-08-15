using System.Collections.Generic;

namespace AutoFighters
{
    [System.Serializable]
    public class MainControllerData
    {
        public GameState gameState;
        public ulong currentAvailableUniqueId;
        public List<CharacterStats> characterList;
        public Inventory inventory;

        public MainControllerData(MainController mainController)
        {
            gameState = mainController.GameState;
            currentAvailableUniqueId = mainController.CurrentAvailableUniqueId;
            characterList = mainController.CharacterList;
            inventory = mainController.Inventory;
        }
    }
}

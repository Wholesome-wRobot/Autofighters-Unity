namespace AutoFighters
{
    [System.Serializable]
    public class MainControllerData
    {
        public GameState gameState;
        public ulong uniqueId;

        public MainControllerData(MainController mainController)
        {
            gameState = mainController.GameState;
            uniqueId = mainController.CurrentAvailableUniqueId;
        }
    }
}

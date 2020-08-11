[System.Serializable]
public class MainControllerData
{
    public GameState gameState;
    public uint uniqueId;

    public MainControllerData(MainController mainController)
    {
        gameState = mainController.gameState;
        uniqueId = mainController.uniqueId;
    }
}

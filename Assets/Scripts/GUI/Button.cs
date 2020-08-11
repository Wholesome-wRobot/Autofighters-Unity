using UnityEngine;

public class Button : MonoBehaviour
{
    public void Start()
    {
    }

	public void ToggleRun()
    {
        if (BattleController.Instance.battleState == BattleState.Running)
            BattleController.Instance.battleState = BattleState.Pause;
        else
            BattleController.Instance.battleState = BattleState.Running;
    }

    public void SaveAll()
    {
        // Save Main controller
        MainControllerData dataMainC = new MainControllerData(MainController.Instance);
        SaveSystem.SaveController(dataMainC, Consts.mainControllerName);

        // Save Battle controller
        BattleControllerData dataBattleC = new BattleControllerData(BattleController.Instance);
        SaveSystem.SaveController(dataBattleC, Consts.battleControllerName);

        // Save characters
        SaveSystem.SaveCharacters();
    }

    public void LoadAll()
    {
        // Load Main Controller
        MainControllerData mainControllerData = (MainControllerData)SaveSystem.LoadController(Consts.mainControllerName);
        MainController.Instance.listCharacters = SaveSystem.LoadCharacters();
        MainController.Instance.gameState = mainControllerData.gameState;
        MainController.Instance.uniqueId = mainControllerData.uniqueId;

        // Load Battle Controller
        BattleControllerData battleControllerData = (BattleControllerData)SaveSystem.LoadController(Consts.battleControllerName);
        BattleController.Instance.battleState = battleControllerData.battleState;
        BattleController.Instance.currentFrame = battleControllerData.currentFrame; 
    }

    public void CreateChar(int factionId)
    {
        CharacterStats newCharStats = new CharacterStats
        {
            faction = (Faction)factionId,
            uniqueId = MainController.Instance.GenerateUniqueID()
        };
        newCharStats.name = $"{newCharStats.faction} ({newCharStats.uniqueId})";
        MainController.Instance.listCharacters.Add(newCharStats);
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        MainController.Instance.LoadScene(Consts.battleSceneName);
        MainController.Instance.gameState = GameState.Battle;
    }
}

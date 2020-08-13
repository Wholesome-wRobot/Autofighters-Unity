using UnityEngine;

namespace AutoFighters
{
    public class Button : MonoBehaviour
    {
        public void ToggleRun()
        {
            if (BattleController.Instance.BattleState == BattleState.Running)
                BattleController.Instance.SetBattleState(BattleState.Pause);
            else if (BattleController.Instance.BattleState == BattleState.Pause || BattleController.Instance.BattleState == BattleState.StartFight)
                BattleController.Instance.SetBattleState(BattleState.Running);
        }

        public void SaveAll()
        {
            // Save Main controller
            MainControllerData dataMainC = new MainControllerData(MainController.Instance);
            SaveSystem.SaveController(dataMainC, Consts.MainControllerName);

            // Save Battle controller
            BattleControllerData dataBattleC = new BattleControllerData(BattleController.Instance);
            SaveSystem.SaveController(dataBattleC, Consts.BattleControllerName);

            // Save characters
            SaveSystem.SaveCharacters();
        }

        public void LoadAll()
        {
            // Load Main Controller
            MainControllerData mainControllerData = (MainControllerData)SaveSystem.LoadController(Consts.MainControllerName);
            MainController.Instance.SetCharactersList(SaveSystem.LoadCharacters());
            MainController.Instance.SetGameState(mainControllerData.gameState);
            MainController.Instance.SetCurrentAvailableUniqueId(mainControllerData.uniqueId);

            // Load Battle Controller
            BattleControllerData battleControllerData = (BattleControllerData)SaveSystem.LoadController(Consts.BattleControllerName);
            BattleController.Instance.SetBattleState(battleControllerData.battleState);
            BattleController.Instance.SetCurrentFrame(battleControllerData.currentFrame);
        }

        public void CreateChar(int factionId)
        {
            CharacterStats newCharStats = new CharacterStats
            {
                Faction = (Faction)factionId,
                UniqueId = MainController.Instance.GenerateUniqueID()
            };
            newCharStats.DisplayName = $"{newCharStats.Faction} ({newCharStats.UniqueId})";
            MainController.Instance.AddCharacterToList(newCharStats);
        }

        public void StartGame()
        {
            Debug.Log("Starting Game");
            MainController.Instance.LoadScene(Consts.BattleSceneName);
            MainController.Instance.SetGameState(GameState.Battle);
        }
    }
}
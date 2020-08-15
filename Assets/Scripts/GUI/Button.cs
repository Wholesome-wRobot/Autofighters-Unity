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
        }

        public void LoadAll()
        {
            MainController.Instance.LoadController((MainControllerData)SaveSystem.GetControllerDataFromFile(Consts.MainControllerName));
            BattleController.Instance.LoadController((BattleControllerData)SaveSystem.GetControllerDataFromFile(Consts.BattleControllerName));
        }

        public void CreateChar(int factionId)
        {
            CharacterStats newCharStats = new CharacterStats();
            newCharStats.SetFaction((Faction)factionId);
            newCharStats.SetUniqueId(MainController.Instance.GenerateUniqueID());
            newCharStats.SetDisplayName($"{newCharStats.Faction} ({newCharStats.UniqueId})");
            MainController.Instance.AddCharacterToList(newCharStats);
            BattleController.Instance.InstantiateCharacter(newCharStats);
        }

        public void StartGame()
        {
            Debug.Log("Starting Game");
            MainController.Instance.LoadScene(Consts.BattleSceneName);
            MainController.Instance.SetGameState(GameState.Battle);
        }

        public void InventoryButton()
        {
            MainController.Instance.SetActiveMenu(1);
        }
    }
}
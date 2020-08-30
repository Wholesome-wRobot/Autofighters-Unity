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
            SerializedMainController dataMainC = new SerializedMainController(MainController.Instance);
            SaveSystem.SaveController(dataMainC, Consts.MainControllerName);

            SerializedBattleController dataBattleC = new SerializedBattleController(BattleController.Instance);
            SaveSystem.SaveController(dataBattleC, Consts.BattleControllerName);
        }

        public void LoadAll()
        {
            object serializedMainCOntroller = SaveSystem.GetControllerDataFromFile(Consts.MainControllerName);
            MainController.Instance.LoadController(serializedMainCOntroller as SerializedMainController);

            object serializedBattleController = SaveSystem.GetControllerDataFromFile(Consts.BattleControllerName);
            BattleController.Instance.LoadController(serializedBattleController as SerializedBattleController);
        }

        public void GenerateChar(int archetype)
        {
            CharacterStats stats = new CharacterStats((CharacterArchetype)archetype);
            MainController.Instance.CharacterManager.AddCharacterToList(stats);
            if (MainController.Instance.GameState == GameState.Battle)
                BattleController.Instance.InstantiateCharacter(stats);
        }

        public void StartGame()
        {
            MainController.Instance.SetGameState(GameState.Battle);
        }

        public void InventoryButton()
        {
            MainController.Instance.SetActiveMenu(MainController.Instance.InventoryManager);
        }
    }
}
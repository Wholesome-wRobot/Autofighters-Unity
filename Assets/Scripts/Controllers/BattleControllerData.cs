[System.Serializable]
public class BattleControllerData
{
    public int currentFrame;
    public BattleState battleState;

    public BattleControllerData(BattleController battleController)
    {
        currentFrame = battleController.currentFrame;
        battleState = battleController.battleState;
    }
}

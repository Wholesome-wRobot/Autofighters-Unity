namespace AutoFighters
{
    [System.Serializable]
    public class BattleControllerData
    {
        public ulong currentFrame;
        public BattleState battleState;

        public BattleControllerData(BattleController battleController)
        {
            currentFrame = battleController.CurrentFrame;
            battleState = battleController.BattleState;
        }
    }
}

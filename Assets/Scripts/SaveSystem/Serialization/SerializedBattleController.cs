using UnityEngine;

namespace AutoFighters
{
    [System.Serializable]
    public class SerializedBattleController
    {
        [SerializeField] private ulong _currentFrame;
        public ulong CurrentFrame { get => _currentFrame; private set => _currentFrame = value;  }

        [SerializeField] private BattleState _battleState;
        public BattleState BattleState { get => _battleState; private set => _battleState = value; }

        public SerializedBattleController(BattleController battleController)
        {
            CurrentFrame = battleController.CurrentFrame;
            BattleState = battleController.BattleState;
        }
    }
}

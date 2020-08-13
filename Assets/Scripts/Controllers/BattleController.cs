using UnityEngine;

namespace AutoFighters
{
    public class BattleController : MonoBehaviour
    {
        public static BattleController CN { get; private set; }
        public int CurrentFrame { get; private set; }
        public BattleState BattleState { get; private set; }

        public static BattleController Instance
        {
            get
            {
                if (CN == null)
                {
                    CN = FindObjectOfType<BattleController>();

                    if (CN == null)
                    {
                        GameObject container = new GameObject(Consts.BattleControllerName);
                        CN = container.AddComponent<BattleController>();
                    }
                }

                return CN;
            }
        }

        public void Start()
        {
            SetCurrentFrame(0);
            SetBattleState(BattleState.StartFight);
        }

        public void SetBattleState(BattleState battleState) { BattleState = battleState; }

        public void SetCurrentFrame(int frame) { CurrentFrame = frame; }

        public void Update()
        {
            if (BattleState == BattleState.Running)
                SetCurrentFrame(CurrentFrame + 1);
        }
    }
}

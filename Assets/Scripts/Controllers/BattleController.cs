using System.Collections;
using TMPro;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public TextMeshProUGUI frameText;

    public static BattleController CN { get; private set; }
    public int currentFrame = 0;
    public BattleState battleState;

    public static BattleController Instance
    {
        get
        {
            if (CN == null)
            {
                CN = FindObjectOfType<BattleController>();

                if (CN == null)
                {
                    GameObject container = new GameObject(Consts.battleControllerName);
                    CN = container.AddComponent<BattleController>();
                }
            }

            return CN;
        }
    }

    public void Start()
    {
        battleState = BattleState.Running;
    }

    public void Update()
    {
        currentFrame = battleState == BattleState.Running ? currentFrame + 1 : currentFrame;

        frameText.SetText(currentFrame.ToString());
    }
}

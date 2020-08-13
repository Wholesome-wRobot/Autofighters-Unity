using System.Linq;
using TMPro;
using UnityEngine;

public class BattleGUI : MonoBehaviour
{
    private TextMeshProUGUI _timer;

    void Awake()
    {
        _timer = GetComponentsInChildren<TextMeshProUGUI>()[0];
    }

    void Update()
    {
        _timer.SetText(BattleController.Instance.CurrentFrame.ToString());
    }
}

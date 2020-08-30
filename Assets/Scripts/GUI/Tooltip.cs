using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private TextMeshProUGUI _tooltipText;
    private RectTransform _panelRectTransform;

    void Awake()
    {
        _panelRectTransform = GetComponentInChildren<RectTransform>();
        _tooltipText = GetComponentInChildren<TextMeshProUGUI>();

        ShowToolTip("SALUT CA VA");
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_panelRectTransform, Input.mousePosition, null, out localPoint);
        _panelRectTransform.localPosition = localPoint;
    }

    private void ShowToolTip(string toolTipString)
    {
        gameObject.SetActive(true);

        _tooltipText.SetText(toolTipString);
        Vector2 backgroundSize = new Vector2(_tooltipText.preferredWidth + 8, _tooltipText.preferredHeight + 8);
        _panelRectTransform.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}

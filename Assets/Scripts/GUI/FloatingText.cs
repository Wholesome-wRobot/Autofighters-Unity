using System;
using TMPro;
using UnityEngine;

public enum FloatingTextType
{
    DamageAlly,
    Heal,
    DamageEnemy,
    Neutral
}

class FloatingText : MonoBehaviour
{
    public string Text { get; private set; }
    public FloatingTextType Type { get; private set; }

    private Vector3 _currentPosition;
    private float _currentVelocity;
    private readonly float _startingVelocity = 0.0006f;
    private float _alpha;

    private TextMeshPro _textMeshPro;

    private RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    void Start()
    {
        _currentVelocity = _startingVelocity;
        _currentPosition = _rectTransform.anchoredPosition;
        _textMeshPro.text = Text;

        // Set color
        if (Type == FloatingTextType.DamageAlly)
        {
            _textMeshPro.color = new Color32(248, 71, 27, 255);
        }
        else if (Type == FloatingTextType.DamageEnemy)
        {
            _textMeshPro.color = new Color32(237, 196, 14, 255);
        }
        else if (Type == FloatingTextType.Heal)
        {
            _textMeshPro.color = new Color32(137, 207, 114, 255);
        }
        else if (Type == FloatingTextType.Neutral)
        {
            _textMeshPro.color = new Color32(255, 255, 255, 255);
        }
    }

    void Update()
    {
        _currentPosition.y += _currentVelocity;
        _rectTransform.anchoredPosition = _currentPosition;

        // Phase 1 - Slow down
        if (_currentVelocity > _startingVelocity / 2)
            _currentVelocity -= 0.0005f * Time.deltaTime;

        // Phase 2 - Slow down more
        if (_currentVelocity < _startingVelocity / 2 && _currentVelocity >= 0)
            _currentVelocity -= 0.0008f * Time.deltaTime;

        // Phase 3 - Disapear
        if (_currentVelocity <= 0)
            _textMeshPro.textInfo.textComponent.alpha -= 3f * Time.deltaTime;

        if (_textMeshPro.textInfo.textComponent.alpha <= 0)
            Destroy(gameObject);
    }

    public void SetText(string text) { Text = text; }
    public void SetType(FloatingTextType type) { Type = type; }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    private SpriteRenderer _characterSpriteRend;
    private TextMeshProUGUI _nameplate; 
    private TextMeshProUGUI _displayState;
    private TextMeshProUGUI _energyText;

    private Image _energyBar;
    private Image _manaBar;
    private Image _healthBar;

    public Animator Anim { get; private set; }
    public CharacterStateMachine CharacterStateMachine { get; private set; }
    public CharacterStats Stats { get; private set; }

    void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        CharacterStateMachine = GetComponentInChildren<CharacterStateMachine>();

        _characterSpriteRend = GetComponentInChildren<SpriteRenderer>();
        _nameplate = GetComponentsInChildren<TextMeshProUGUI>()[0];
        _displayState = GetComponentsInChildren<TextMeshProUGUI>()[1];
        _energyText = GetComponentsInChildren<TextMeshProUGUI>()[2];

        // Needs refactoring
        _energyBar = GetComponentsInChildren<Image>()[1];
        _healthBar = GetComponentsInChildren<Image>()[2];
        _manaBar = GetComponentsInChildren<Image>()[3];
    }

    void Start() 
    {
        _nameplate.SetText(Stats.DisplayName);

        // Flip if enemy
        if (Stats.Faction == Faction.Enemy)
            _characterSpriteRend.flipX = true; 
    }

    void Update()
    {
        if (BattleController.Instance.BattleState == BattleState.Running)
        {
            Stats.CurrentEnergy += Stats.EnergyRate;
            //stats.currentMana -= 0.5f;
            //stats.currentHealth += 0.2f;

            _energyText.SetText(Stats.CurrentEnergy.ToString());
        }

        _energyBar.fillAmount = Stats.CurrentEnergy / Stats.MaxEnergy;
        _manaBar.fillAmount = Stats.CurrentMana / Stats.MaxMana;
        _healthBar.fillAmount = Stats.CurrentHealth / Stats.MaxHealth;

        _displayState.SetText(CharacterStateMachine.currentStateName);

        // Character's turn to act
        if (Stats.CurrentEnergy >= Stats.MaxEnergy && BattleController.Instance.BattleState == BattleState.Running)
        {
            CharacterStateMachine.SetCharacterState(new StartTurnState(CharacterStateMachine));
        }
    }

    public void LoadStats(CharacterStats stats)
    {
        Stats = stats;
    }

    public void EquipSpell(SpellID spellId, int slot)
    {
        Stats.SpellSlots[slot] = spellId;
    }

    public void ReceiveDamage(int amount) 
    {
        Stats.CurrentHealth -= amount;
        Stats.CurrentHealth = Math.Max(0, Stats.CurrentHealth);

        // Floating text
        if (Stats.Faction == Faction.Ally)
            SpawnFloatingText(amount.ToString(), FloatingTextType.DamageAlly);
        else
            SpawnFloatingText(amount.ToString(), FloatingTextType.DamageEnemy);

        Anim.SetTrigger(AnimationTrigger.TakeDamage.ToString());
    }

    public void ReceiveHeal(int amount)
    {
        Stats.CurrentHealth += amount;
        Stats.CurrentHealth = Math.Min(Stats.MaxHealth, Stats.CurrentHealth);

        // Floating text
        SpawnFloatingText(amount.ToString(), FloatingTextType.Heal);

        Anim.SetTrigger(AnimationTrigger.TakeDamage.ToString());
    }

    public void SpawnFloatingText(string text, FloatingTextType type)
    {
        FloatingText textInstance = Instantiate(Resources.Load<FloatingText>("Prefabs/FloatingText"));

        textInstance.GetComponent<FloatingText>().SetText(text);
        textInstance.GetComponent<FloatingText>().SetType(type);

        Vector3 characterPosition = GetComponent<Transform>().position;

        textInstance.GetComponent<RectTransform>().position = new Vector3(characterPosition.x, characterPosition.y + 1, 0.5f);
    }
}

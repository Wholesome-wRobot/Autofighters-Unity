using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    public SpriteRenderer characterSpriteRend;

    public Canvas canvas;

    public TextMeshProUGUI nameplate;
    public TextMeshProUGUI displayState;
    public TextMeshProUGUI energyText;

    public Image energyBar;
    public Image manaBar;
    public Image healthBar;

    public CharacterStats stats;
    public CharacterStateMachine characterStateMachine;

    public Animator anim;

    void Start()
    {
        // Initialize
        anim = GetComponentInChildren<Animator>();
        characterSpriteRend = GetComponentInChildren<SpriteRenderer>();
        nameplate.SetText(stats.name);

        // Flip if enemy
        if (stats.faction == Faction.Enemy)
            characterSpriteRend.flipX = true; 
    }

    void Update()
    {
        if (BattleController.Instance.battleState == BattleState.Running)
        {
            stats.currentEnergy += stats.energyRate;
            //stats.currentMana -= 0.5f;
            //stats.currentHealth += 0.2f;

            energyText.SetText(stats.currentEnergy.ToString());
        }

        energyBar.fillAmount = stats.currentEnergy / stats.maxEnergy;
        manaBar.fillAmount = stats.currentMana / stats.maxMana;
        healthBar.fillAmount = stats.currentHealth / stats.maxHealth;

        displayState.SetText(characterStateMachine.currentStateName);

        // Character's turn to act
        if (stats.currentEnergy >= stats.maxEnergy && BattleController.Instance.battleState == BattleState.Running)
        {
            characterStateMachine.SetCharacterState(new StartTurnState(characterStateMachine));
        }
    }

    public void EquipSpell(SpellID spellName, int emplacement)
    {
        stats.spellSlots[emplacement] = spellName;
    }

    public void ReceiveDamage(int dmg) 
    {
        stats.currentHealth -= dmg;
        stats.currentHealth = Math.Max(0, stats.currentHealth);
        anim.SetTrigger(AnimationTrigger.TakeDamage.ToString());
    }

    public void ReceiveHeal(int healAmount)
    {
        stats.currentHealth += healAmount;
        stats.currentHealth = Math.Min(stats.maxHealth, stats.currentHealth);
    }
}

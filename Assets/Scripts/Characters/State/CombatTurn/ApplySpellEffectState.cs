using System.Collections;
using UnityEngine;

internal class ApplySpellEffectState : CharacterState
{
    public ApplySpellEffectState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        DisplayName = "Applying Spell effect";
    }

    public override IEnumerator Run()
    {
        Spell selectedSpell = characterStateMachine.selectedSpell;

        foreach (Character target in characterStateMachine.targetsList)
        {
            Debug.Log($"{characterStateMachine.character.stats.name} uses {selectedSpell.DisplayName} on {target.stats.name}");

            // Heal
            if (selectedSpell.Heal > 0)
            {
                target.ReceiveHeal(characterStateMachine.selectedSpell.Heal);
            }

            // Damage
            if (selectedSpell.Damage > 0)
            {
                target.ReceiveDamage(characterStateMachine.selectedSpell.Damage);
            }
        }

        yield return new WaitForSeconds(0.5f);

        characterStateMachine.SetCharacterState(new EndTurnState(characterStateMachine));
    }
}
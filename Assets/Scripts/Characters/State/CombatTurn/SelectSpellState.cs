using System.Collections;
using UnityEngine;

public class SelectSpellState : CharacterState
{
    public SelectSpellState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        DisplayName = "Selecting spell";
    }

    public override IEnumerator Run()
    {
        // Loop in character's spell slots
        foreach (SpellID spellName in characterStateMachine.character.stats.spellSlots)
        {
            if (spellName != SpellID.None)
            {
                characterStateMachine.selectedSpell = SpellsDB.GetSpellById(spellName);
                break;
            }
        }

        yield return new WaitForSeconds(0.5f);

        if (characterStateMachine.selectedSpell != null)
        {
            Debug.Log($"{characterStateMachine.character.stats.name} selected {characterStateMachine.selectedSpell.DisplayName}");
            characterStateMachine.SetCharacterState(new SelectTargetsState(characterStateMachine));
        }
        else
        {
            characterStateMachine.SetCharacterState(new EndTurnState(characterStateMachine));
        }
    }
}
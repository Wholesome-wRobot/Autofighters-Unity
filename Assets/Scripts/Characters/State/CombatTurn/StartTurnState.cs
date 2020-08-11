using System.Collections;
using UnityEngine;

public class StartTurnState : CharacterState
{
    public StartTurnState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {
        DisplayName = "Start Turn";
    }

    public override IEnumerator Run()
    {
        BattleController.Instance.battleState = BattleState.Turn;
        Debug.Log($"Start acting : {characterStateMachine.character.stats.name}");

        yield return new WaitForSeconds(0.5f);

        characterStateMachine.SetCharacterState(new SelectSpellState(characterStateMachine));
    } 
}

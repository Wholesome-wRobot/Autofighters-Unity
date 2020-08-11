using System.Collections;
using UnityEngine;

public class EndTurnState : CharacterState
{
    public EndTurnState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        DisplayName = "Ending turn";
    }

    public override IEnumerator Run()
    {
        yield return new WaitForSeconds(0.5f);

        characterStateMachine.character.stats.currentEnergy = 0;
        characterStateMachine.ResetStateMachine();

        BattleController.Instance.battleState = BattleState.Running;
    }
}
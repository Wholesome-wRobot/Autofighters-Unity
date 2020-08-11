using System.Collections;
using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {
        DisplayName = "Idle";
    }

    public override IEnumerator Run()
    {
        Debug.Log(characterStateMachine.character.stats.name + " in Idle state");
        yield break;
    }
}
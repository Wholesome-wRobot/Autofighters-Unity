using System.Collections;

public class IdleState : CharacterState
{
    public override string DisplayName => "Idle";

    public IdleState(CharacterStateMachine characterStateMachine) : base (characterStateMachine) { }

    public override IEnumerator Run()
    {
        yield break;
    }
}
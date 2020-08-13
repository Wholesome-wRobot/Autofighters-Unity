using System.Collections;

public class StartTurnState : CharacterState
{
    public override string DisplayName => "Start Turn";

    public StartTurnState(CharacterStateMachine characterStateMachine) : base (characterStateMachine) { }

    public override IEnumerator Run()
    {
        BattleController.Instance.SetBattleState(BattleState.Turn);

        yield return _stateMachine.StateTransitionTime;
        _stateMachine.SetCharacterState(new SelectSpellState(_stateMachine));
    } 
}

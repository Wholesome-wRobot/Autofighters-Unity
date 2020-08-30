using System.Collections;

namespace AutoFighters
{
    public class EndTurnState : CharacterState
    {
        public override string DisplayName => "Ending turn";

        public EndTurnState(CharacterStateMachine stateMachine) : base(stateMachine) { }

        public override IEnumerator Run()
        {
            yield return _stateMachine.StateTransitionTime;

            _stateMachine.Character.Stats.SetCurrentEnergy(0);
            _stateMachine.ResetStateMachine();
            BattleController.Instance.SetBattleState(BattleState.Running);
        }
    }
}
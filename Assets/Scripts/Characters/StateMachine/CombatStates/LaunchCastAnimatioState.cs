using System.Collections;

namespace AutoFighters
{
    public class LaunchCastAnimatioState : CharacterState
    {
        public override string DisplayName => "Cast animation";

        public LaunchCastAnimatioState(CharacterStateMachine stateMachine) : base(stateMachine) { }

        public override IEnumerator Run()
        {
            _stateMachine.Character.Anim.SetTrigger(_stateMachine.SelectedSpell.CastAnimationTrigger.ToString());

            yield return _stateMachine.StateTransitionTime;
        }
    }
}
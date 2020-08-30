using System.Collections;
using UnityEngine;

namespace AutoFighters
{
    public class DieState : CharacterState
    {
        public override string DisplayName => "Die";

        public DieState(CharacterStateMachine characterStateMachine) : base(characterStateMachine) { }

        public override IEnumerator Run()
        {
            BattleController.Instance.SetBattleState(BattleState.Turn);

            _stateMachine.Character.Anim.SetTrigger(AnimationTrigger.Die.ToString());

            yield return new WaitForSeconds(3);

            _stateMachine.Character.DestroyInstance();
            BattleController.Instance.SetBattleState(BattleState.Running);

            yield break;
        }
    }
}
using System.Collections;

namespace AutoFighters
{
    public abstract class CharacterState
    {
        protected CharacterStateMachine _stateMachine;

        public abstract string DisplayName { get; }

        public CharacterState(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual IEnumerator Run()
        {
            yield break;
        }
    }
}

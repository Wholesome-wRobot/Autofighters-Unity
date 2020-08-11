using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class CharacterState
{
    protected CharacterStateMachine characterStateMachine;

    public string DisplayName { get; set; }

    public CharacterState(CharacterStateMachine stateMachine)
    {
        characterStateMachine = stateMachine;
    }

    public virtual IEnumerator Run()
    {
        yield break;
    }
}

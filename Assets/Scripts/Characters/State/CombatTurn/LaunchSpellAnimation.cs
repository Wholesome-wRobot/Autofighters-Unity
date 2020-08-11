using System.Collections;
using UnityEngine;

public class LaunchSpellAnimation : CharacterState
{
    public LaunchSpellAnimation(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        DisplayName = "Using spell";
    }

    public override IEnumerator Run()
    {
        // If damage animation
        if (characterStateMachine.selectedSpell.Damage != 0)
        {
            characterStateMachine.character.anim.SetTrigger(AnimationTrigger.Attack.ToString());
        }
        
        // If spell animation A CHANGER BIEN ENTENDU
        if (characterStateMachine.selectedSpell.Damage == 0)
        {
            characterStateMachine.character.anim.SetTrigger(AnimationTrigger.Attack.ToString());
        }

        yield return new WaitForSeconds(0.5f);
    }
}
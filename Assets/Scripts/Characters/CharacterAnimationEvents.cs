using UnityEngine;

class CharacterAnimationEvents : MonoBehaviour
{
    public Character character;

    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    public void HitEvent(string msg)
    {
        character.characterStateMachine.TriggerSPellImpact();
    }
}

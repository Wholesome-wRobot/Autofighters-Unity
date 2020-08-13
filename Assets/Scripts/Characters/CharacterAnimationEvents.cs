using UnityEngine;

class CharacterAnimationEvents : MonoBehaviour
{
    private Character _character;

    void Start()
    {
        _character = GetComponentInParent<Character>();
    }

    public void HitEvent()
    {
        _character.CharacterStateMachine.TriggerSpellInstanceCreation();
    }
}

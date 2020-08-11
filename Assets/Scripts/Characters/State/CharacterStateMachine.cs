using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    public Character character;
    
    public Spell selectedSpell = null;
    public List<Character> targetsList = new List<Character>();

    protected CharacterState currentState;
    public string currentStateName;

    void Start()
    {
        character = GetComponent<Character>();
        SetCharacterState(new IdleState(this));
    }

    public void SetCharacterState(CharacterState characterState)
    {
        currentState = characterState;
        currentStateName = characterState.DisplayName;
        StartCoroutine(characterState.Run());
    }

    // Called at End turn
    public void ResetStateMachine()
    {
        selectedSpell = null;
        targetsList.Clear();
        SetCharacterState(new IdleState(this));
    }

    public void TriggerSPellImpact()
    {
        SetCharacterState(new ApplySpellEffectState(this));
    }
}

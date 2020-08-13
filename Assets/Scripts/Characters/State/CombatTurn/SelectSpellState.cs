using System.Collections;

public class SelectSpellState : CharacterState
{
    public override string DisplayName => "Selecting spell";

    public SelectSpellState(CharacterStateMachine stateMachine) : base (stateMachine) { }

    public override IEnumerator Run()
    {
        // Loop in character's spell slots
        foreach (SpellID spellName in _stateMachine.Character.Stats.SpellSlots)
        {
            if (spellName != SpellID.None)
            {
                _stateMachine.SetSelectedSpell(SpellsDB.Get(spellName));
                break;
            }
        }

        yield return _stateMachine.StateTransitionTime;

        // Return spell or pass turn
        if (_stateMachine.SelectedSpell != null)
            _stateMachine.SetCharacterState(new SelectTargetsState(_stateMachine));
        else
        {
            _stateMachine.Character.SpawnFloatingText("NO SPELL", FloatingTextType.Neutral);
            _stateMachine.SetCharacterState(new EndTurnState(_stateMachine));
        }
    }
}
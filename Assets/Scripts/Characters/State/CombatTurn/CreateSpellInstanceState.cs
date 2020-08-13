using System.Collections;

internal class CreateSpellInstanceState : CharacterState
{
    public override string DisplayName => "Creating spell instance";

    public CreateSpellInstanceState(CharacterStateMachine stateMachine) : base (stateMachine) { }

    public override IEnumerator Run()
    {
        foreach (Character target in _stateMachine.TargetsList)
        {
            _stateMachine.InstantiateSpell(_stateMachine.SelectedSpell, _stateMachine.Character, target);
            yield return _stateMachine.StateTransitionTime;
        }

        yield return _stateMachine.StateTransitionTime;
        _stateMachine.SetCharacterState(new EndTurnState(_stateMachine));
    }
}
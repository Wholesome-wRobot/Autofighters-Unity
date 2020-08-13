using System.Collections;

namespace AutoFighters
{
    public class SelectSpellState : CharacterState
    {
        public override string DisplayName => "Selecting spell";

        public SelectSpellState(CharacterStateMachine stateMachine) : base(stateMachine) { }

        public override IEnumerator Run()
        {
            // Loop in character's spell slots
            foreach (Spell spell in _stateMachine.Character.Stats.SpellSlots)
            {
                if (spell != null)
                {
                    _stateMachine.SetSelectedSpell(spell);
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
}
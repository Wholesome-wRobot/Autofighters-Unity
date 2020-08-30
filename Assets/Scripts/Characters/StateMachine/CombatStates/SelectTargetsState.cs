using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoFighters
{
    public class SelectTargetsState : CharacterState
    {
        public override string DisplayName => "Selecting targets";

        public SelectTargetsState(CharacterStateMachine stateMachine) : base(stateMachine) { }

        public override IEnumerator Run()
        {
            _stateMachine.SetTargetsList(Object.FindObjectsOfType<Character>().ToList());

            List<Character> targetsList = _stateMachine.TargetsList;

            // If no spell selected, we end turn
            if (_stateMachine.SelectedSpell == null)
                _stateMachine.SetCharacterState(new EndTurnState(_stateMachine));

            // Filter targetsList by faction
            FilterTargetsListByFaction(_stateMachine, targetsList);

            // Filter targetList by condition

            // Filter targetList by single/multitarget
            FilterTargetsByMultiOrSingle(_stateMachine, targetsList);

            // No target found
            if (targetsList.Count <= 0)
            {
                _stateMachine.Character.SpawnFloatingText("NO TARGET", FloatingTextType.Neutral);
                _stateMachine.SetCharacterState(new EndTurnState(_stateMachine));
            }
            else
            {
                _stateMachine.SetTargetsList(targetsList);
                _stateMachine.SetCharacterState(new LaunchCastAnimatioState(_stateMachine));
            }

            yield return _stateMachine.StateTransitionTime;
        }

        // Filter targetList by single/multitarget (we remove targets from the list until correct amount)
        private static void FilterTargetsByMultiOrSingle(CharacterStateMachine stateMachine, List<Character> targetsList)
        {
            while (targetsList.Count > stateMachine.SelectedSpell.TargetAmount)
            {
                int randomNumber = Random.Range(0, targetsList.Count);
                targetsList.RemoveAt(randomNumber);
            }
        }

        // Filter Target List by faction
        private static void FilterTargetsListByFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
        {
            // If target faction is opposite
            if (stateMachine.SelectedSpell.DefaultTargetFaction == TargetFaction.Opposite)
                KeepOnlyOppositeFaction(stateMachine, targetsList);

            // If target faction is same
            if (stateMachine.SelectedSpell.DefaultTargetFaction == TargetFaction.Same)
                KeepOnlySameFaction(stateMachine, targetsList);
        }

        // Get a list of all characters of opposite faction
        private static void KeepOnlyOppositeFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
        {
            if (stateMachine.Character.Stats.Faction == Faction.Enemy)
                targetsList.RemoveAll(t => t.Stats.Faction == Faction.Enemy);

            if (stateMachine.Character.Stats.Faction == Faction.Ally)
                targetsList.RemoveAll(t => t.Stats.Faction == Faction.Ally);
        }

        // Get a list of all characters of same faction
        private static void KeepOnlySameFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
        {
            if (stateMachine.Character.Stats.Faction == Faction.Enemy)
                targetsList.RemoveAll(t => t.Stats.Faction == Faction.Ally);

            if (stateMachine.Character.Stats.Faction == Faction.Ally)
                targetsList.RemoveAll(t => t.Stats.Faction == Faction.Enemy);
        }

        // Select one random Character from list
        private static Character SelectOneRandomFromList(List<Character> characterList)
        {
            int randomNumber = Random.Range(0, characterList.Count);
            return characterList[randomNumber];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectTargetsState : CharacterState
{
    public SelectTargetsState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
        DisplayName = "Selecting targets";
    }

    public override IEnumerator Run()
    {
        characterStateMachine.targetsList = Object.FindObjectsOfType<Character>().ToList();

        List<Character> targetsList = characterStateMachine.targetsList;

        // If no spell selected, we end turn
        if (characterStateMachine.selectedSpell == null)
            characterStateMachine.SetCharacterState(new EndTurnState(characterStateMachine));

        // Filter targetsList by faction
        FilterTargetsListByFaction(characterStateMachine, targetsList);

        // Filter targetList by condition

        // Filter targetList by single/multitarget
        FilterTargetsByMultiOrSingle(characterStateMachine, targetsList);

        // Log
        if (targetsList.Count <= 0)
            Debug.Log($"No target found for {characterStateMachine.selectedSpell.DisplayName}");
        else
            Debug.Log($"{targetsList.Count} target(s) found");

        characterStateMachine.targetsList = targetsList;

        yield return new WaitForSeconds(0.5f);

        if (targetsList.Count > 0)
            characterStateMachine.SetCharacterState(new LaunchSpellAnimation(characterStateMachine));
        else
            characterStateMachine.SetCharacterState(new EndTurnState(characterStateMachine));
    }

    // Filter targetList by single/multitarget (we remove targets from the list until correct amount)
    private static void FilterTargetsByMultiOrSingle(CharacterStateMachine stateMachine, List<Character> targetsList)
    {
        while (targetsList.Count > stateMachine.selectedSpell.TargetAmount)
        {
            int randomNumber = Random.Range(0, targetsList.Count);
            targetsList.RemoveAt(randomNumber);
        }
    }

    // Filter Target List by faction
    private static void FilterTargetsListByFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
    {
        // If target faction is opposite
        if (stateMachine.selectedSpell.DefaultTargetFaction == TargetFaction.Opposite)
            KeepOnlyOppositeFaction(stateMachine, targetsList);

        // If target faction is same
        if (stateMachine.selectedSpell.DefaultTargetFaction == TargetFaction.Same)
            KeepOnlySameFaction(stateMachine, targetsList);
    }

    // Get a list of all characters of opposite faction
    private static void KeepOnlyOppositeFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
    {
        if (stateMachine.character.stats.faction == Faction.Enemy)
            targetsList.RemoveAll(t => t.stats.faction == Faction.Enemy);

        if (stateMachine.character.stats.faction == Faction.Ally)
            targetsList.RemoveAll(t => t.stats.faction == Faction.Ally);
    }

    // Get a list of all characters of same faction
    private static void KeepOnlySameFaction(CharacterStateMachine stateMachine, List<Character> targetsList)
    {
        if (stateMachine.character.stats.faction == Faction.Enemy)
            targetsList.RemoveAll(t => t.stats.faction == Faction.Ally);

        if (stateMachine.character.stats.faction == Faction.Ally)
            targetsList.RemoveAll(t => t.stats.faction == Faction.Enemy);
    }

    // Select one random Character from list
    private static Character SelectOneRandomFromList(List<Character> characterList)
    {
        int randomNumber = Random.Range(0, characterList.Count);
        return characterList[randomNumber];
    }
}
﻿using System.Collections.Generic;
using UnityEngine;

namespace AutoFighters
{
    public class CharacterStateMachine : MonoBehaviour
    {
        public Character Character { get; private set; }
        public ISpell SelectedSpell { get; private set; }
        public List<Character> TargetsList { get; private set; }
        public WaitForSeconds StateTransitionTime { get; private set; }

        public string currentStateName; // Just to be shown in editor

        void Awake()
        {
            Character = GetComponentInParent<Character>();
        }

        void Start()
        {
            SetSelectedSpell(null);
            SetCharacterState(new IdleState(this));
            SetTargetsList(new List<Character>());
            StateTransitionTime = new WaitForSeconds(0.5f);
        }

        public void SetSelectedSpell(ISpell spell) { SelectedSpell = spell; }

        public void SetTargetsList(List<Character> targetsList) { TargetsList = targetsList; }

        public void SetCharacterState(CharacterState characterState)
        {
            currentStateName = characterState.DisplayName;
            StartCoroutine(characterState.Run());
        }

        // Called from End turn state
        public void ResetStateMachine()
        {
            SetSelectedSpell(null);
            TargetsList.Clear();
            SetCharacterState(new IdleState(this));
        }

        // Called in the middle of the cast animation
        public void TriggerSpellInstanceCreation()
        {
            SetCharacterState(new CreateSpellInstanceState(this));
        }

        public void InstantiateSpell(ISpell spell, Character caster, Character target)
        {
            SpellInstance spellInstance = Instantiate(Resources.Load<SpellInstance>("Prefabs/SpellInstance"));

            spellInstance.SetSpell(spell);
            spellInstance.SetCaster(caster);
            spellInstance.SetTarget(target);
        }
    }
}

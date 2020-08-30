using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace AutoFighters
{
    public class Character : MonoBehaviour
    {
        private SpriteRenderer _characterSpriteRend;
        private TextMeshProUGUI _nameplate;
        private TextMeshProUGUI _displayState;
        private TextMeshProUGUI _energyText;

        public CharacterSpot mySpot;
        public FloatingText floatingTextPrefab;

        private Image _energyBar;
        private Image _manaBar;
        private Image _healthBar;

        public Animator Anim { get; private set; }
        public CharacterStateMachine CharacterStateMachine { get; private set; }
        public CharacterStats Stats { get; private set; }

        void Awake()
        {
            Anim = GetComponentInChildren<Animator>();
            CharacterStateMachine = GetComponentInChildren<CharacterStateMachine>();

            _characterSpriteRend = GetComponentInChildren<SpriteRenderer>();
            _nameplate = GetComponentsInChildren<TextMeshProUGUI>()[0];
            _displayState = GetComponentsInChildren<TextMeshProUGUI>()[1];
            _energyText = GetComponentsInChildren<TextMeshProUGUI>()[2];

            // Needs refactoring
            _energyBar = GetComponentsInChildren<Image>()[1];
            _healthBar = GetComponentsInChildren<Image>()[2];
            _manaBar = GetComponentsInChildren<Image>()[3];
        }

        void Start()
        {
            _nameplate.SetText(Stats.DisplayName);

            Anim.runtimeAnimatorController = Stats.AnimatorController;

            // Flip if enemy
            if (Stats.Faction == Faction.Enemy)
                _characterSpriteRend.flipX = true;
        }

        void Update()
        {
            if (BattleController.Instance.BattleState == BattleState.Running)
            {
                Stats.TickEnergy();
                _energyText.SetText(Stats.CurrentEnergy.ToString());
            }

            _energyBar.fillAmount = (float)(Stats.CurrentEnergy / Stats.MaxEnergy);
            _manaBar.fillAmount = (float)(Stats.CurrentMana / Stats.MaxMana); 
            _healthBar.fillAmount = (float)(Stats.CurrentHealth / Stats.MaxHealth);

            _displayState.SetText(CharacterStateMachine.currentStateName);

            // Character's turn to act
            if (Stats.CurrentEnergy >= Stats.MaxEnergy && BattleController.Instance.BattleState == BattleState.Running)
            {
                CharacterStateMachine.SetCharacterState(new StartTurnState(CharacterStateMachine));
            }

            if (Stats.CurrentHealth <= 0)
            {
                CharacterStateMachine.SetCharacterState(new DieState(CharacterStateMachine));
            }
        }

        public void AttachStats(CharacterStats stats)
        {
            Stats = stats;
        }

        public void DestroyInstance()
        {
            Debug.Log("Destroying " + Stats.DisplayName);
            mySpot.DetachCharacter();
            Destroy(gameObject);
        }

        public void ReceiveDamage(int amount)
        {
            Stats.ModifyCurrentHealth(-amount);

            // Floating text
            if (Stats.Faction == Faction.Ally)
                SpawnFloatingText(amount.ToString(), FloatingTextType.DamageAlly);
            else
                SpawnFloatingText(amount.ToString(), FloatingTextType.DamageEnemy);

            Anim.SetTrigger(AnimationTrigger.TakeDamage.ToString());
        }

        public void ReceiveHeal(int amount)
        {
            Stats.ModifyCurrentHealth(amount);

            // Floating text
            SpawnFloatingText(amount.ToString(), FloatingTextType.Heal);

            Anim.SetTrigger(AnimationTrigger.TakeDamage.ToString());
        }

        public void SpawnFloatingText(string text, FloatingTextType type)
        {
            FloatingText textInstance = Instantiate(floatingTextPrefab);

            textInstance.GetComponent<FloatingText>().SetText(text);
            textInstance.GetComponent<FloatingText>().SetType(type);

            Vector3 characterPosition = GetComponent<Transform>().position;

            textInstance.GetComponent<RectTransform>().position = new Vector3(characterPosition.x, characterPosition.y + 1, 0.5f);
        }
    }
}
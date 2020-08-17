using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoFighters
{
    public class BattleController : MonoBehaviour
    {
        private bool _instantiateAllFlag; // used because Destroying objects only happens after update
        public static BattleController CN { get; private set; }
        public ulong CurrentFrame { get; private set; }
        public BattleState BattleState { get; private set; }

        public GameObject SpotsLayout;
        public GameObject BattleGUI;

        public static BattleController Instance
        {
            get
            {
                if (CN == null)
                {
                    CN = FindObjectOfType<BattleController>();
                    if (CN == null)
                    {
                        GameObject container = new GameObject(Consts.BattleControllerName);
                        CN = container.AddComponent<BattleController>();
                    }
                }
                return CN;
            }
        }

        void Start()
        {
            SetCurrentFrame(0);
            SetBattleState(BattleState.StartFight);

            Instantiate(BattleGUI);
            Instantiate(SpotsLayout);
        }

        void Update()
        {
            if (BattleState == BattleState.Running)
                SetCurrentFrame(CurrentFrame + 1);

            if (_instantiateAllFlag) // enfore character instantiation at the next possible frame
                InstantiateAllCharacters();
        }

        public void SetBattleState(BattleState battleState) { BattleState = battleState; }
        public void SetCurrentFrame(ulong frame) { CurrentFrame = frame; }

        public void LoadController(BattleControllerData data)
        {
            SetBattleState(data.battleState);
            SetCurrentFrame(data.currentFrame);

            // Destroy current characters in combat
            foreach (Character character in FindObjectsOfType<Character>().ToList())
                character.DestroyInstance();

            InstantiateAllCharacters();
        }

        public void InstantiateAllCharacters()
        {
            if (!_instantiateAllFlag)
                _instantiateAllFlag = true;
            else
            {
                if (FindObjectsOfType<Character>().Length <= 0)
                {
                    // Instantiate characters
                    foreach (CharacterStats characterStats in MainController.Instance.CharacterManager.CharacterList)
                        InstantiateCharacter(characterStats);

                    _instantiateAllFlag = false;
                }
            }
        }

        public void InstantiateCharacter(CharacterStats characterStats)
        {
            // Create array of already instantiated characters
            List<Character> charsAlreadyInstantiated = FindObjectsOfType<Character>().ToList();

            // Check for duplicate
            if (charsAlreadyInstantiated.Any(c => c.Stats.UniqueId == characterStats.UniqueId))
            {
                Debug.LogWarning($"Character with unique id {characterStats.UniqueId} already exists. Skipping.");
                return;
            }

            // Find spot
            CharacterSpot firstSpotAvailable = CharacterSpot.GetFirstAvailableSpot(characterStats.Faction);

            if (firstSpotAvailable == null)
            {
                Debug.LogError($"Alert, no spot available for {characterStats.DisplayName}");
                return;
            }

            Character characterInstance = Instantiate(Resources.Load<Character>("Prefabs/Character"), firstSpotAvailable.transform.position, Quaternion.identity);

            characterInstance.GetComponent<Character>().LoadStats(characterStats);

            firstSpotAvailable.GetComponent<CharacterSpot>().AttachCharacter(characterStats);
        }
    }
}

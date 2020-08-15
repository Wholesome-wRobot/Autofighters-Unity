using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutoFighters
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private List<CharacterStats> _characterList;
        public List<CharacterStats> CharacterList { get => _characterList; private set => _characterList = value; }

        [SerializeField] private Inventory _inventory;
        public Inventory Inventory { get => _inventory; private set => _inventory = value; }

        private readonly int _maxNumberOfAllies = 4;

        public GameState GameState { get; private set; }
        public ulong CurrentAvailableUniqueId { get; private set; } 

        public static MainController CN { get; private set; }

        public static MainController Instance
        {
            get
            {
                if (CN == null)
                {
                    CN = FindObjectOfType<MainController>();
                    if (CN == null)
                    {
                        GameObject container = new GameObject(Consts.MainControllerName);
                        CN = container.AddComponent<MainController>();
                    }
                }
                return CN;
            }
        }

        private void Awake()
        {
            // Random seed
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);

            if (CN != null)
                Destroy(CN);
            else
                CN = this;

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            GameState = GameState.MainMenu;

            CharacterList = new List<CharacterStats>();
            Inventory = new Inventory();

            Inventory.AddToInventory(new BasicAttack());
            Inventory.AddToInventory(new BasicHeal());
            Inventory.AddToInventory(new FiftyPercent());
            Inventory.AddToInventory(new GreaterThan());
        }

        public void SetCurrentAvailableUniqueId(ulong id) { CurrentAvailableUniqueId = id; }

        public void SetGameState(GameState gameState) { GameState = GameState; }

        public void SetCharactersList(List<CharacterStats> list) { CharacterList = list; }

        public void AddCharacterToList(CharacterStats characterStats)
        {
            if (characterStats.Faction == Faction.Ally && GetListAllies().Count < _maxNumberOfAllies)
                CharacterList.Add(characterStats);
            else if (characterStats.Faction == Faction.Enemy)
                CharacterList.Add(characterStats);
        }

        public List<CharacterStats> GetListAllies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Ally).ToList();
        }

        public List<CharacterStats> GetListEnemies()
        {
            return CharacterList.Where(s => s.Faction == Faction.Enemy).ToList();
        }

        public List<CharacterStats> GetListAllCharacters()
        {
            return CharacterList;
        }

        public void ClearCharacterList()
        {
            CharacterList.Clear();
        }

        public void LoadScene(string levelToLoad)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        public ulong GenerateUniqueID()
        {
            CurrentAvailableUniqueId += 1;
            return CurrentAvailableUniqueId;
        }

        public void LoadController(MainControllerData data)
        {
            SetGameState(data.gameState);
            CurrentAvailableUniqueId = data.currentAvailableUniqueId;
            CharacterList = data.characterList;
            Inventory = data.inventory;
        }
    }
}
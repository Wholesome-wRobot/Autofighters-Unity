using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutoFighters
{
    public class MainController : MonoBehaviour
    {
        [SerializeField]
        private List<CharacterStats> _characterList;
        public List<CharacterStats> CharacterList { get { return _characterList; } private set => _characterList = value; }

        [SerializeField]
        private Inventory _inventory;
        public Inventory Inventory { get { return _inventory; } private set => _inventory = value; }

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
            Random.InitState((int)System.DateTime.Now.Ticks);

            if (CN != null)
                Destroy(CN);
            else
                CN = this;

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            CharacterList = new List<CharacterStats>();
            Inventory = new Inventory();
            GameState = GameState.MainMenu;
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
    }
}
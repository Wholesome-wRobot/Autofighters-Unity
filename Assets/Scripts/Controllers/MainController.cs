using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutoFighters
{
    public class MainController : MonoBehaviour
    {
        public GameObject CharacterManagerPrefab;
        public GameObject EventSystemPrefab;
        public GameObject InventoryManagerPrefab;

        [SerializeField] private IMenuPanel _currentActivePanel;
        public IMenuPanel CurrentActivePanel { get => _currentActivePanel; private set => _currentActivePanel = value; }

        [SerializeField] private CharacterManager _characterManager;
        public CharacterManager CharacterManager { get => _characterManager; private set => _characterManager = value; }

        [SerializeField] private Inventory _inventory;
        public Inventory InventoryManager { get => _inventory; private set => _inventory = value; }

        [SerializeField] private GameState _gameState;
        public GameState GameState { get => _gameState; private set => _gameState = value; }

        //[SerializeField] private ulong _currentAvailableUniqueId;
        //public ulong CurrentAvailableUniqueId { get => _currentAvailableUniqueId; private set => _currentAvailableUniqueId = value; }

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
                Destroy(gameObject);
            else
                CN = this;

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            GameState = GameState.MainMenu;

            // Bindings
            GameObject characterManagerPrefab = Instantiate(CharacterManagerPrefab);
            CharacterManager = characterManagerPrefab.GetComponent<CharacterManager>();

            GameObject inventoryManagerPrefab = Instantiate(InventoryManagerPrefab);
            InventoryManager = inventoryManagerPrefab.GetComponent<Inventory>();

            Instantiate(EventSystemPrefab);
        }

        public void SetActiveMenu(IMenuPanel panel)
        {
            if (CurrentActivePanel != null)
            {
                CurrentActivePanel.ClosePanel();
                CurrentActivePanel = null;
            }
            else if (CurrentActivePanel != panel)
            {
                panel.OpenPanel();
                CurrentActivePanel = panel;
            }
        }

        //public void SetCurrentAvailableUniqueId(ulong id) { CurrentAvailableUniqueId = id; }

        public void SetGameState(GameState gameState) 
        {
            if (GameState == gameState) return;

            GameState = gameState;

            if (gameState == GameState.Battle)
            {
                LoadScene(Consts.BattleSceneName);
            }
            else if (gameState == GameState.MainMenu)
            {
                LoadScene(Consts.MainMenuSceneName);
            }
        }

        public void LoadScene(string levelToLoad)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        /*public ulong GenerateUniqueID()
        {
            CurrentAvailableUniqueId += 1;
            return CurrentAvailableUniqueId;
        }*/

        public void LoadController(MainControllerData data)
        {
            SetGameState(data.gameState);
            //CurrentAvailableUniqueId = data.currentAvailableUniqueId;
            CharacterManager.SetCharactersList(data.characterList);
            InventoryManager.LoadInventory(data.inventory);
            SetActiveMenu(null);
        }
    }
}
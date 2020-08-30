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
        public GameObject LowerCharPanelPrefab;

        [SerializeField] private IMenuPanel _currentActivePanel;
        public IMenuPanel CurrentActivePanel { get => _currentActivePanel; private set => _currentActivePanel = value; }

        [SerializeField] private CharacterManager _characterManager;
        public CharacterManager CharacterManager { get => _characterManager; private set => _characterManager = value; }

        [SerializeField] private Inventory _inventoryManager;
        public Inventory InventoryManager { get => _inventoryManager; private set => _inventoryManager = value; }

        [SerializeField] private LowerCharPanel _lowerCharPanel;
        public LowerCharPanel LowerCharPanel { get => _lowerCharPanel; private set => _lowerCharPanel = value; }

        [SerializeField] private GameState _gameState;
        public GameState GameState { get => _gameState; private set => _gameState = value; }

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
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);

            if (CN != null)
                Destroy(gameObject);
            else
                CN = this;

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            // Bindings, Carfeul with the order
            GameObject inventoryManagerPrefab = Instantiate(InventoryManagerPrefab);
            InventoryManager = inventoryManagerPrefab.GetComponent<Inventory>();

            GameObject lowerCharPanelPrefab = Instantiate(LowerCharPanelPrefab);
            LowerCharPanel = lowerCharPanelPrefab.GetComponent<LowerCharPanel>();

            GameObject characterManagerPrefab = Instantiate(CharacterManagerPrefab);
            CharacterManager = characterManagerPrefab.GetComponent<CharacterManager>();

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

        public void LoadController(SerializedMainController data)
        {
            SetGameState(data.GameState);
            CharacterManager.LoadCharacterListFromSave(data.SerializedCharacterList);
            InventoryManager.LoadInventory(data.SerializedInventory);
            SetActiveMenu(null);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private List<CharacterStats> _charactersList;
    private int _maxNumberOfAllies = 4;

    public GameState GameState { get; private set; }
    public uint CurrentAvailableUniqueId { get; private set; }

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
        SpellsDB.Initialize();

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
        _charactersList = new List<CharacterStats>();
        GameState = GameState.MainMenu;
    }

    public void SetCurrentAvailableUniqueId(uint id) { CurrentAvailableUniqueId = id; }

    public void SetGameState(GameState gameState) { GameState = GameState; }

    public void SetCharactersList(List<CharacterStats> list) { _charactersList = list; }

    public void AddCharacterToList(CharacterStats characterStats)
    {
        if (characterStats.Faction == Faction.Ally && GetListAllies().Count < _maxNumberOfAllies)
            _charactersList.Add(characterStats);
        else if (characterStats.Faction == Faction.Enemy)
            _charactersList.Add(characterStats);
    }

    public List<CharacterStats> GetListAllies() 
    {
        return _charactersList.Where(s => s.Faction == Faction.Ally).ToList();
    }

    public List<CharacterStats> GetListEnemies()
    {
        return _charactersList.Where(s => s.Faction == Faction.Enemy).ToList();
    }

    public List<CharacterStats> GetListAllCharacters()
    {
        return _charactersList;
    }

    public void ClearCharacterList()
    {
        _charactersList.Clear();
    }

    public void LoadScene(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public uint GenerateUniqueID()
    {
        CurrentAvailableUniqueId += 1;
        return CurrentAvailableUniqueId;
    }
}

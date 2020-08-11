using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public List<CharacterStats> listCharacters = new List<CharacterStats>();
    public GameState gameState;
    public uint uniqueId;

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
                    GameObject container = new GameObject(Consts.mainControllerName);
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
        gameState = GameState.MainMenu;
    }
    
    void Update()
    {
    }

    public void LoadScene(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public uint GenerateUniqueID()
    {
        uniqueId += 1;
        return uniqueId;
    }
}

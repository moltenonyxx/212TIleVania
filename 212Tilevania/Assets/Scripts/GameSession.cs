using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{


    [SerializeField] int playerLives = 3;
    
    void Awake()
    {
        //starts with 4.35
        // create our Singleton
        int numberGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    //when player dies do certain things
    //reduce # of lives
    //if no lives then restart the whole game
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

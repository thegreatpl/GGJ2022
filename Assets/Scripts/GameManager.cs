using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject PlayerPrefab;

    public GameObject GameUIPrefab;

    public List<GameObject> GibsPrefabs;

    public GameObject GibsSound; 



    public GameObject Player;

    public GameUIScript GameUIScript;

    public Camera Camera;

    public MusicPlayer MusicPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        //only one GameManager allowed. 
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;


        MusicPlayer = gameObject.GetComponent<MusicPlayer>();

        //debug code. 
        if (SceneManager.GetActiveScene().name != "MainMenu" && Application.isEditor)
            StartCoroutine(StartNewGame()); 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void ChangeScene(string sceneName, Vector3 playerPos)
    {
        if (sceneName == "victory")
        {
            WinGame(); 
            return; 
        }

        SceneManager.LoadScene(sceneName);
        Player.transform.position = playerPos;

    }

    #region MenuOptions

    public void StartGame()
    {
        StartCoroutine(StartNewGame());
    }

    public void QuitGame() 
    { 
        Application.Quit();
    }


    #endregion

    public IEnumerator StartNewGame()
    {
        Player = Instantiate(PlayerPrefab);
        DontDestroyOnLoad(Player); 
        Camera.transform.position = new Vector3(0, 0, Camera.transform.position.z);
        Camera.transform.SetParent(Player.transform, true);
        
        yield return null;
        var gameUI = Instantiate(GameUIPrefab);
        DontDestroyOnLoad (gameUI);
        GameUIScript = gameUI.GetComponent<GameUIScript>();
        yield return null;

        if (SceneManager.GetActiveScene().name == "MainMenu" || !Application.isEditor)
            ChangeScene("Level_1", Vector3.zero); 
    }



    public void GameOver()
    {
        StartCoroutine(GameUIScript.GetComponentInChildren<GameOverScreenScript>().FadeToBlack(false)); 

    }

    public void WinGame()
    {
        StartCoroutine(GameUIScript.GetComponentInChildren<GameOverScreenScript>().FadeToBlack(true));
        Player.transform.DetachChildren();
        Destroy(Player.gameObject);
    }

    public void GoToMenu()
    {
        StopAllCoroutines(); 
        Destroy(GameUIScript.gameObject);
        if (Player != null)
            Destroy(Player);
       Camera.transform.position = new Vector3(0, 0, Camera.transform.position.z); 
        SceneManager.LoadScene("MainMenu");

    }
}

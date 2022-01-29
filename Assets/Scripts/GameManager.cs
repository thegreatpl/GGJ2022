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



    public GameObject Player;

    public GameUIScript GameUIScript;



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
        //todo; game over screen. 
        Destroy(GameUIScript.gameObject);
    }
}

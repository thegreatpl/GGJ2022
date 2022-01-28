using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject PlayerPrefab;



    public GameObject Player; 

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


    public IEnumerator StartNewGame()
    {
        Player = Instantiate(PlayerPrefab);
        DontDestroyOnLoad(Player); 
        yield return null;
    }



    public void GameOver()
    {
        //todo; game over screen. 
    }
}

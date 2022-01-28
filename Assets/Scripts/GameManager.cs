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
        instance = this;
        StartCoroutine(StartNewGame()); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ChangeScene("testing"); 
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  
    }


    public IEnumerator StartNewGame()
    {
        Player = Instantiate(PlayerPrefab);
        DontDestroyOnLoad(Player); 
        yield return null;
    }
}

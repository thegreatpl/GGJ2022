using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    /// <summary>
    /// Music for this level
    /// </summary>
    public string Music = "Industria"; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.MusicPlayer.ChangeSong(Music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

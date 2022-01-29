using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    int countDown; 

    public Text UIText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        countDown--; 
        if (countDown < 0)
        {
            UIText.text = ""; 
        }
    }

    public void DisplayText(string message, int time = 10000)
    {
        UIText.text = message;
        countDown = time; 
    }
}

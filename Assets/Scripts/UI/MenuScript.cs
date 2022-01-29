using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    

    public ColourSwitchScript colourSwitchScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleColour()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ToggleColour()
    {
        yield return null; 
        while (true)
        {
            if (colourSwitchScript.IsBlack)
                colourSwitchScript.SetWhite();
            else
                colourSwitchScript.SetBlack();
            colourSwitchScript.IsBlack = !colourSwitchScript.IsBlack;

            yield return new WaitForSeconds(3); 
        }

    }

    public void StartNewGame()
    {
        GameManager.instance.StartGame();
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame(); 
    }
}

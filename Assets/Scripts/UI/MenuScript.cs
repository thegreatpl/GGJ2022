using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public GameObject CreditsPanelObject;

    public GameObject MenuObj; 



    public ColourSwitchScript colourSwitchScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleColour()); 
        CreditsPanelObject.SetActive(false);
        MenuObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (CreditsPanelObject.activeSelf && Input.anyKeyDown)
        {
            CreditsPanelObject.SetActive(false);
            MenuObj.SetActive(true);
        }
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


    public void ShowCredits()
    {
        CreditsPanelObject.SetActive(true);
        MenuObj?.SetActive(false);
    }
}

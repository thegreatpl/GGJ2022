using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameOverScreenScript : MonoBehaviour
{
    public Image Panel;

    public Text GameOverText;

    public Text VictoryText; 
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        VictoryText.gameObject.SetActive(false );
        Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator FadeToBlack(bool victory)
    {
        while (Panel.color.a < 1)
        {
            Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, Panel.color.a + 0.01f);
            yield return new WaitForSeconds(0.1f); 
        }
        if (victory)
            VictoryText.gameObject.SetActive(true);
        else
            GameOverText.gameObject.SetActive(true);

        yield return new WaitForSeconds(10); 


        GameManager.instance.GoToMenu();
    }


}

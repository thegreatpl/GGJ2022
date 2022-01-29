using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameOverScreenScript : MonoBehaviour
{
    public Image Panel;

    public Text GameOverText; 
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator FadeToBlack()
    {
        while (Panel.color.a < 1)
        {
            Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, Panel.color.a + 0.01f);
            yield return new WaitForSeconds(0.1f); 
        }
        GameOverText.gameObject.SetActive(true);

        yield return new WaitForSeconds(10); 


        GameManager.instance.GoToMenu();
    }
}

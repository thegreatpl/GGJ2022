using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColourSwitchScript : MonoBehaviour
{
    public Tilemap BackGround;

    public Tilemap WhiteCollider;

    public Tilemap BlackCollider;

    public Tilemap AlwaysCollider; 

    public bool IsBlack = false;

    public Color BlackColor = new Color(0.75f, 0.75f, 0.75f); 

    // Start is called before the first frame update
    void Start()
    {
        if (IsBlack)
            SetBlack();
        else
            SetWhite();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SwtichColour(); 
    }

    public void SwtichColour()
    {
        if (IsBlack)
            SetBlack();
        else
            SetWhite();

        IsBlack = !IsBlack; 
    }

    void SetBlack()
    {
        BackGround.color = BlackColor;
        BlackCollider.color = BlackColor;
        AlwaysCollider.color = BlackColor;

        WhiteCollider.gameObject.SetActive(false);
        BlackCollider.gameObject.SetActive(true);
    }
    void SetWhite()
    {
        BackGround.color = Color.white;
        AlwaysCollider.color = Color.white;

        WhiteCollider.gameObject.SetActive(true);
        BlackCollider.gameObject.SetActive(false);
    }
}

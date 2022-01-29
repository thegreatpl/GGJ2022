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
        //tempcode. Remove later. 
        if (Input.GetKeyDown(KeyCode.Q))
            SwtichColour(); 
    }

    public void SwtichColour()
    {
        if (IsBlack)
        {
            if (WhiteCollider.GetTile(WhiteCollider.WorldToCell(GameManager.instance.Player.transform.position)) == null)
                SetWhite();
        }
        else
        {
            if (BlackCollider.GetTile(BlackCollider.WorldToCell(GameManager.instance.Player.transform.position)) == null)
                SetBlack();
        }

        IsBlack = !IsBlack; 
    }

    public void SetBlack()
    {
        BackGround.color = BlackColor;
        BlackCollider.color = BlackColor;
        AlwaysCollider.color = BlackColor;

        WhiteCollider.gameObject.SetActive(false);
        BlackCollider.gameObject.SetActive(true);

        GameManager.instance.Camera.backgroundColor = Color.black; 
    }
    public void SetWhite()
    {
        BackGround.color = Color.white;
        AlwaysCollider.color = Color.white;

        WhiteCollider.gameObject.SetActive(true);
        BlackCollider.gameObject.SetActive(false);

        GameManager.instance.Camera.backgroundColor = Color.white;

    }
}

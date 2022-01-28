using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public int HP;

    public int MaxHP;

    public float Speed;

    public int Attack; 

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
            if (tag == "Player")
                GameManager.instance.GameOver(); 
        }
    }
}

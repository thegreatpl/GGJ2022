using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GibsScript : MonoBehaviour
{
    public int LifeTime = 1000; 

    // Start is called before the first frame update
    void Start()
    {
        float baseFore = 10f;
        float maxForce = 20;
        var rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(Random.Range(baseFore, maxForce), Random.Range(baseFore, maxForce)));
        rigid.AddTorque(Random.Range(1, 10));
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime--; 
        if (LifeTime < 0)
            Destroy(gameObject);
    }
}

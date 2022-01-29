using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownToDestruction : MonoBehaviour
{
    public float Seconds = 2; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(Seconds);

        Destroy(gameObject);
    }
}

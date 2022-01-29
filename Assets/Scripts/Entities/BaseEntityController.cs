using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attributes))]
public class BaseEntityController : MonoBehaviour
{
    public Movement Movement;

    public Attributes Attributes; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();

        Attributes = GetComponent<Attributes>();

        Attributes.onDeath += () =>
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }; 
    }

    // Update is called once per frame
    void Update()
    {
       

    }


    protected void Gibsify()
    {
        Instantiate(GameManager.instance.GibsSound, transform.position, Quaternion.identity);
        for(int idx = 0; idx < Random.Range(3, 10); idx++)
        {
            var gib = Instantiate(GameManager.instance.GibsPrefabs.RandomElement()); 
            gib.transform.position = transform.position;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    /// <summary>
    /// How much damage this script does. 
    /// </summary>
    public int DamageAmount; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Attributes>()?.TakeDamage(DamageAmount);
    }
}

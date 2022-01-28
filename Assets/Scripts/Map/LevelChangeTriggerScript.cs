using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeTriggerScript : MonoBehaviour
{
    /// <summary>
    /// Level to transition to. 
    /// </summary>
    public string Level;

    /// <summary>
    /// Location they arrive in. 
    /// </summary>
    public Vector2 Location; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.ChangeScene(Level, new Vector3(Location.x, Location.y, 0)); 
        }
    }
}

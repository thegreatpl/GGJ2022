using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundTriggerScript : MonoBehaviour
{
    public AudioSource AudioSource; 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            if (!AudioSource.isPlaying)
                AudioSource.Play(); 
        }
    }
}

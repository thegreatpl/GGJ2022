using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EntitySoundScript : MonoBehaviour
{

    public AudioSource AudioSource; 

    public AudioClip RandomNoise;

    public AudioClip DamageNoise;

    public float RandomNoiseMinSeconds = 0.4f;

    public float RandomNoiseMaxSeconds = 2f;

    public float RandomNoiseCooldown = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        if (RandomNoise != null)
            StartCoroutine(RandomNoisePlayer()); 

        var attributes = GetComponent<Attributes>();
        if (attributes != null && DamageNoise != null)
        {
            attributes.onDamage += () =>
            {
                AudioSource.PlayOneShot(DamageNoise);
            };
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomNoisePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(RandomNoiseMinSeconds, RandomNoiseMaxSeconds));

            AudioSource.PlayOneShot(RandomNoise);

            yield return new WaitForSeconds(RandomNoiseCooldown);

        }
        
    }
}

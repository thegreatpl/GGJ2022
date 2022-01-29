using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Song
{
    public AudioClip AudioClip;
    public string Name; 
}

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    public float FadeSpeed = 0.1f;

    public string CurrentSong; 

    public List<Song> songs;

    Dictionary<string, AudioClip> songsDictionary = new Dictionary<string, AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach (Song s in songs)
            songsDictionary.Add(s.Name, s.AudioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSong(string newSong)
    {
        if (songsDictionary.ContainsKey(newSong) && newSong != CurrentSong)
            StartCoroutine(TransitionSongs(newSong));
    }


    IEnumerator TransitionSongs(string nextSong)
    {
        var volume = audioSource.volume; 
        while (audioSource.volume > 0)
        {
            audioSource.volume -= FadeSpeed;
            yield return new WaitForSeconds(0.5f);
        }
        audioSource.clip = songsDictionary[nextSong]; 
        audioSource.Play();
        while (audioSource.volume < volume)
        {
            audioSource.volume += FadeSpeed;
            yield return new WaitForSeconds(0.5f);
        }
        audioSource.volume = volume;
    }
}

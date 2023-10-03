using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        
    
    }

    public void PlayMusic(AudioClip musicClip)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }
}

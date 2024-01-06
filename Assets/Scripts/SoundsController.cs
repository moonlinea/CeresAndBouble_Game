using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private GameObject onMusicIcon;
    [SerializeField] private GameObject offMusicIcon;

    private bool isMusicPlaying = false;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Açıklamalar ve isimlendirme iyileştirmeleri yapıldı.
    public void ToggleMusic()
    {
        Debug.Log("TOGGLE MUSIC!!");
        isMusicPlaying = !isMusicPlaying;

        foreach (AudioSource audioSource in audioSources)
        {
            if (isMusicPlaying)
                audioSource.Play();
            else
                audioSource.Stop();
        }

        ChangeIcon(isMusicPlaying);
    }

    // İkon değiştirme metodunda birleştirme yapıldı.
    void ChangeIcon(bool iconIsActive)
    {
        onMusicIcon.SetActive(!iconIsActive);
        offMusicIcon.SetActive(iconIsActive);
    }
}

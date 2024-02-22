using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining; // Geriye kalan s�re
    [SerializeField] private float maxTime; // Maksimum s�re
    [SerializeField] private Slider slider; // S�re �ubu?u

    [SerializeField] private GameObject timeIsUpPanel;
    [SerializeField] private AudioSource timeIsUpMusic;
    [SerializeField] private Animator panelAnimator;
    private int timeIsUpFlag = 0;

    private void Start()
    {
        timeIsUpFlag = 0;
        slider.maxValue = maxTime; // S�re �ubu?unun maksimum de?erini ayarla
        timeRemaining = maxTime; // Geriye kalan s�reyi maksimum s�reyle ba?lat
    }

    private void Update()
    {
        slider.value = CalculateSliderValue(); // S�re �ubu?unun de?erini g�ncelle

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Geriye kalan s�reyi azalt
        }

        if (timeRemaining <= 0)
        {
            if (timeIsUpFlag == 0)
            {
                TimeIsUp();
            }
        }
    }

    private void TimeIsUp()
    {
        Time.timeScale = 0f;
        timeIsUpPanel.SetActive(true);
        timeIsUpMusic.Play();
        panelAnimator.Play("timeIsUpPanelAnim");
        timeIsUpFlag += 1;
    }

    public float CalculateSliderValue()
    {
        return timeRemaining; // S�re �ubu?u de?erini hesapla ve d�nd�r
    }

    public void UpdateTime()
    {
        if (timeRemaining + 5 <= maxTime)
        {
            timeRemaining += 5; // S�reye 5 ekleyin
            Debug.Log("Time Artt? +++++++++++++++++++++++++++++====== " + timeRemaining);
            slider.value = CalculateSliderValue(); // S�re �ubu?unun de?erini g�ncelle
        }
        else if (timeRemaining > maxTime)
        {
            timeRemaining = maxTime;
            slider.value = CalculateSliderValue();
        }
    }
}

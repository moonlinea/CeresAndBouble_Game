using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining; // Geriye kalan süre
    [SerializeField] private float maxTime; // Maksimum süre
    [SerializeField] private Slider slider; // Süre çubu?u

    [SerializeField] private GameObject timeIsUpPanel;
    [SerializeField] private AudioSource timeIsUpMusic;
    [SerializeField] private Animator panelAnimator;
    private int timeIsUpFlag = 0;

    private void Start()
    {
        timeIsUpFlag = 0;
        slider.maxValue = maxTime; // Süre çubu?unun maksimum de?erini ayarla
        timeRemaining = maxTime; // Geriye kalan süreyi maksimum süreyle ba?lat
    }

    private void Update()
    {
        slider.value = CalculateSliderValue(); // Süre çubu?unun de?erini güncelle

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Geriye kalan süreyi azalt
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
        return timeRemaining; // Süre çubu?u de?erini hesapla ve döndür
    }

    public void UpdateTime()
    {
        if (timeRemaining + 5 <= maxTime)
        {
            timeRemaining += 5; // Süreye 5 ekleyin
            Debug.Log("Time Artt? +++++++++++++++++++++++++++++====== " + timeRemaining);
            slider.value = CalculateSliderValue(); // Süre çubu?unun de?erini güncelle
        }
        else if (timeRemaining > maxTime)
        {
            timeRemaining = maxTime;
            slider.value = CalculateSliderValue();
        }
    }
}

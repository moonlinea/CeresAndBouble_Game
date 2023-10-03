using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining; // Geriye kalan süre
    [SerializeField] private float maxTime; // Maksimum süre
    [SerializeField] private Slider slider; // Süre çubuðu

    [SerializeField] private GameObject TimeisupPanel;
    [SerializeField] private AudioSource TIUMusic;
    [SerializeField] private Animator anim;
    int a = 0;
   
  
    private void Start()
    {
        a = 0;
        slider.maxValue = maxTime; // Süre çubuðunun maksimum deðerini ayarla
        timeRemaining = maxTime; // Geriye kalan süreyi maksimum süreyle baþlat
    }

    private void Update()
    {
        slider.value = CalculateSliderValue(); // Süre çubuðunun deðerini güncelle

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Geriye kalan süreyi azalt
        }

        if (timeRemaining <= 0)
        {
            if (a == 0) Timeisup();

        }
    }
    public void Timeisup()
    {
        Time.timeScale = 0f;
        TimeisupPanel.SetActive(true);
        TIUMusic.Play();
        TIUMusic.Play();
        anim.Play("timeisupPanelAnim");
       
        
        
        a+=1;
    }
  
    float CalculateSliderValue()
    {
        return timeRemaining; // Süre çubuðu deðerini hesapla ve döndür
    }
    
    public void UpdateTime()
    {
        
        if (timeRemaining +5<=maxTime)
        {
            timeRemaining += 5; // Süreye 5 ekleyin
            Debug.Log("Time Arttý+++++++++++++++++++++++++++++======" +timeRemaining);
            
            slider.value = CalculateSliderValue(); // Süre çubuðunun deðerini güncelleyin
        }
        else if (timeRemaining > maxTime)
        {
            timeRemaining = 100;
            slider.value = CalculateSliderValue();
        }
           
        
    }
   

}

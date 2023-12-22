using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Ba�lang�� seviyesi
    
    private GameObject astroClone; // Astro klonunu temsil eden de�i�ken
    private LevelController levelController; // LevelController scriptine eri�mek i�in referans
    bool gameEnded;
    private GameManager GM;
    [SerializeField] private TextMeshProUGUI wichLevel;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1f; // Oyun h�z�n� varsay�lan de�ere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        wichLevel.text +=(currentLevel-1).ToString();
        
           

        Debug.Log("Ac?k Olan Son Level====" + (currentLevel -1));
    }

    // Update is called once per frame
    private void Update()
    {
        {            // Astro klonunu sahnede arar
            astroClone = GameObject.FindGameObjectWithTag("Ball");
            

            // Astro klonunun var olup olmad���n� kontrol eder
            if (astroClone == null)
            {
                if (gameEnded == false)
                {
                    gameEnded = true;
                    LevelCompleted();
                }

            }
        }
    }
   
    public void LevelCompleted()
    {
        if(currentLevel>LevelController.playerLevel)
        {
            LevelController.playerLevel++;
            
        }
        LoadLevel();



    }

    public void LoadLevel()
    {
       
        currentLevel++;
        SceneManager.LoadScene(currentLevel); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Ba�lang�� seviyesi
    private int Leveltut;
    private GameObject astroClone; // Astro klonunu temsil eden de�i�ken
    private LevelController levelController; // LevelController scriptine eri�mek i�in referans
    bool gameende;
    private GameManager GM;
    [SerializeField] private TextMeshProUGUI wichLevel;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1f; // Oyun h�z�n� varsay�lan de�ere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        wichLevel.text +=(currentLevel-1).ToString();
        
        Leveltut = currentLevel;
        gameende = true;
      

        Debug.Log("A��k Olan Son Level====" + (currentLevel -1));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        {            // Astro klonunu sahnede arar
            astroClone = GameObject.FindGameObjectWithTag("Ball");
            // Astro klonunun var olup olmad���n� kontrol eder
            if (astroClone == null)
            {
                if (gameende == true)
                {
                    LevelCompleted(); // Top yoksa LevelCompleted fonksiyonunu �a��r
                }

            }
        }
    }
   
    public void LevelCompleted()
    {
        gameende = false;
        Leveltut++;
        currentLevel++; // Mevcut seviyeyi bir art�r

       
        if (currentLevel < SceneManager.sceneCountInBuildSettings -1) // E�er mevcut seviye sahne say�s�ndan k���kse
        {
            currentLevel -- ;
          
            if (currentLevel > PlayerPrefs.GetInt("levelAt")) // Mevcut seviye, kaydedilen en y�ksek seviyeden b�y�kse
            {
                Debug.Log("2 if ge�ti " + currentLevel);
                PlayerPrefs.SetInt("levelAt", currentLevel); // Yeni en y�ksek seviyeyi kaydet
               
                PlayerPrefs.Save();
                
            }

            LoadLevel(Leveltut); // Yeni seviyeyi y�kle
        }
        else
        {
            SceneManager.LoadScene(0); // Ana men�y� y�kle veya istedi�iniz ba�ka bir sahneyi y�kleyebilirsiniz
        }
        

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // Belirtilen seviyeyi y�kle
    }
}

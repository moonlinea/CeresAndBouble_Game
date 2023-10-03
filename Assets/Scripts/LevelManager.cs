using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Baþlangýç seviyesi
    private int Leveltut;
    private GameObject astroClone; // Astro klonunu temsil eden deðiþken
    private LevelController levelController; // LevelController scriptine eriþmek için referans
    bool gameende;
    private GameManager GM;
    [SerializeField] private TextMeshProUGUI wichLevel;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1f; // Oyun hýzýný varsayýlan deðere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        wichLevel.text +=(currentLevel-1).ToString();
        
        Leveltut = currentLevel;
        gameende = true;
      

        Debug.Log("Açýk Olan Son Level====" + (currentLevel -1));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        {            // Astro klonunu sahnede arar
            astroClone = GameObject.FindGameObjectWithTag("Ball");
            // Astro klonunun var olup olmadýðýný kontrol eder
            if (astroClone == null)
            {
                if (gameende == true)
                {
                    LevelCompleted(); // Top yoksa LevelCompleted fonksiyonunu çaðýr
                }

            }
        }
    }
   
    public void LevelCompleted()
    {
        gameende = false;
        Leveltut++;
        currentLevel++; // Mevcut seviyeyi bir artýr

       
        if (currentLevel < SceneManager.sceneCountInBuildSettings -1) // Eðer mevcut seviye sahne sayýsýndan küçükse
        {
            currentLevel -- ;
          
            if (currentLevel > PlayerPrefs.GetInt("levelAt")) // Mevcut seviye, kaydedilen en yüksek seviyeden büyükse
            {
                Debug.Log("2 if geçti " + currentLevel);
                PlayerPrefs.SetInt("levelAt", currentLevel); // Yeni en yüksek seviyeyi kaydet
               
                PlayerPrefs.Save();
                
            }

            LoadLevel(Leveltut); // Yeni seviyeyi yükle
        }
        else
        {
            SceneManager.LoadScene(0); // Ana menüyü yükle veya istediðiniz baþka bir sahneyi yükleyebilirsiniz
        }
        

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // Belirtilen seviyeyi yükle
    }
}

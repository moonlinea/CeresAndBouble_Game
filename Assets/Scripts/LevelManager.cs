using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Baþlangýç seviyesi
    
    private GameObject astroClone; // Astro klonunu temsil eden deðiþken
    private LevelController levelController; // LevelController scriptine eriþmek için referans
    bool gameEnded;
    private GameManager GM;
    [SerializeField] private TextMeshProUGUI wichLevel;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1f; // Oyun hýzýný varsayýlan deðere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        wichLevel.text +=(currentLevel-1).ToString();
        
           

        Debug.Log("Ac?k Olan Son Level====" + (currentLevel -1));
    }

    // Update is called once per frame
    private void Update()
    {
        {            // Astro klonunu sahnede arar
            astroClone = GameObject.FindGameObjectWithTag("Ball");
            

            // Astro klonunun var olup olmadýðýný kontrol eder
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

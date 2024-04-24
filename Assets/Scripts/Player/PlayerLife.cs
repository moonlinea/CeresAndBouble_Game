
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] public static  int playerLife = 5; // Oyuncunun baþlangýç hayat sayýsý
    [SerializeField] private AudioSource gameoverMusicClip; // Game Over müzik sesi
    [SerializeField] private AudioSource crushMusicClip; // Ezmek sesi
    [SerializeField] private GameObject gameOverPanel; // Game Over paneli
    [SerializeField] private Image[] lives; // Hayat simgelerinin dizisi
    private AdMobManager adMobManager;
    private void Start()
    {
        adMobManager = new AdMobManager();
        UpdateLivesUI(); // Hayat simgelerini güncelle
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ball" || col.collider.tag == "Obstacles")
        {
           
                LoseLife(); // Hayat kaybet
            
        }
        else if (col.collider.tag == "ItemLife")
        {
            WinLife();
        }
    }



    void LoseLife()
    {
        playerLife--; // Hayat sayýsýný azalt
     

        UpdateLivesUI(); // Hayat simgelerini güncelle

        if (playerLife <= 0)
        {
            GameOver(); // Hayatlar tükendiðinde oyunu bitir

        }
        else
        {
            RestartLevel(); // Hayatlar hala varsa seviyeyi yeniden baþlat
        }

    }
    void WinLife()
    {
        if (playerLife <5)
        {
            playerLife++;
            UpdateLivesUI(); // Hayat simgelerini güncelle
        }
        else Debug.Log("Full Life");

    }

    void UpdateLivesUI()
    {

        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = i < playerLife; // Hayat simgelerini güncelle ve göster/ gizle
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aktif olan seviyeyi yeniden baþlat

    }

    void GameOver()
    {
       adMobManager.LoadInterstitialAd(true);
        playerLife = 5;
        Time.timeScale = 0f; // Oyun zamanýný durdur
        gameOverPanel.SetActive(true); // Game Over panelini aktif hale getir
        gameoverMusicClip.Play(); // Game Over müziðini çal
        crushMusicClip.Play(); // Ezmek sesini çal
        // Hayat sayýsýný sýfýrla
       
        Debug.Log("GAME OVER!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private static int playerLife = 5; // Oyuncunun ba�lang�� hayat say�s�
    [SerializeField] private AudioSource gameoverMusicClip; // Game Over m�zik sesi
    [SerializeField] private AudioSource CrushMusicClip; // Ezmek sesi
    [SerializeField] private GameObject GameOverP; // Game Over paneli
    [SerializeField] private Image[] lives; // Hayat simgelerinin dizisi

    private void Start()
    {
        UpdateLivesUI(); // Hayat simgelerini g�ncelle
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ball") // �arp��ma etiketi "Ball" olan bir nesneyle ger�ekle�irse
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
        playerLife--; // Hayat say�s�n� azalt
        UpdateLivesUI(); // Hayat simgelerini g�ncelle

        if (playerLife <= 0)
        {
            GameOver(); // Hayatlar t�kendi�inde oyunu bitir
        }
        else
        {
            RestartLevel(); // Hayatlar hala varsa seviyeyi yeniden ba�lat
        }

    }
    void WinLife()
    { if (playerLife < 6)
        {
            playerLife++;
            UpdateLivesUI(); // Hayat simgelerini g�ncelle
        }
        else Debug.Log("Full Life");
        
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = i < playerLife; // Hayat simgelerini g�ncelle ve g�ster/ gizle
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aktif olan seviyeyi yeniden ba�lat
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Oyun zaman�n� durdur
        GameOverP.SetActive(true); // Game Over panelini aktif hale getir
        gameoverMusicClip.Play(); // Game Over m�zi�ini �al
        CrushMusicClip.Play(); // Ezmek sesini �al
        playerLife = 5; // Hayat say�s�n� s�f�rla
        Debug.Log("GAME OVER!");
    }
}

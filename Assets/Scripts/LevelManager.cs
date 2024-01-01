using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Ba?lang?� seviyesi
    private GameObject astroClone; // Astro klonunu temsil eden de?i?ken
    private LevelController levelController; // LevelController scriptine eri?mek i�in referans
    private bool gameEnded;
    private GameManager gameManager; // GameManager scriptine eri?mek i�in referans
    [SerializeField] private TextMeshProUGUI whichLevel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // Oyun h?z?n? varsay?lan de?ere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        whichLevel.text += (currentLevel - 1).ToString();

        Debug.Log("A�?k Olan Son Level====" + (currentLevel - 1));
    }

    // Update is called once per frame
    private void Update()
    {
        // Astro klonunu sahnede arar
        astroClone = GameObject.FindGameObjectWithTag("Ball");

        // Astro klonunun var olup olmad???n? kontrol eder
        if (astroClone == null)
        {
            if (!gameEnded)
            {
                gameEnded = true;
                LevelCompleted();
            }
        }
    }

    public void LevelCompleted()
    {
        if (currentLevel > LevelController.PlayerLevel)
        {
            LevelController.PlayerLevel++;
        }

        LoadLevel();
    }

    public void LoadLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
}

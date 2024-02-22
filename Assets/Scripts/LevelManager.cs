using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int currentLevel; // Ba?lang?ç seviyesi
    private GameObject astroClone; // Astro klonunu temsil eden de?i?ken
    private LevelController levelController; // LevelController scriptine eri?mek için referans
    private bool gameEnded;
    private GameManager gameManager; // GameManager scriptine eri?mek için referans
    [SerializeField] private TextMeshProUGUI whichLevel;
    [SerializeField] public GameObject scorePanel;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // Oyun h?z?n? varsay?lan de?ere ayarla
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        whichLevel.text += (currentLevel - 1).ToString();

    }

    // Update is called once per frame
    private void LateUpdate()
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
        if (currentLevel < SceneManager.sceneCountInBuildSettings - 1)
        {
            if (currentLevel > LevelController.PlayerLevel)
            {
                LevelController.PlayerLevel++;
            }
            scorePanel.SetActive(true);

        }
        else
        {
            // Tüm seviyeler tamamlandı, oyun bitti
            Debug.Log("Oyun bitti!");
        }
    }

    public void LoadLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
}

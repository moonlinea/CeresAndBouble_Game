using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public GameObject[] panels;

    // PauseButton
    public GameObject pausePanel;
    bool isPauseActive = true;

    private void Start()
    {
        // ?lk ba?ta yap?lacak i?lemler
    }

    public void StartButton()
    {
        // Hangi bölümde kald?ysa oradan ba?lat?r
    }

    public void RestartButton()
    {
        ClosePanels();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseButton()
    {
        if (isPauseActive)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Oyun durdu");
            isPauseActive = false;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("Oyuna devamke");
            isPauseActive = true;
        }
    }

    public void MuteButton()
    {
        // Oyun sesini açar veya kapat?r
    }

    public void LevelButton()
    {
        // Hangi levele t?klarsa e?er kilitli de?ilse o leveli açar
    }

    public void ExitButton()
    {
        ClosePanels();
        SceneManager.LoadScene("Menu");
    }

    public void QuitButton()
    {
        // Oyunu tamamen kapat?r
    }

    public void ClosePanels()
    {
        foreach (GameObject panel in panels)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
        }
    }
}

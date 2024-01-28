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
    public GameObject helpPanel;
    bool isPauseActive = true;




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
    public void HelpButton()
    {
        if (isPauseActive)
        {
            pausePanel.SetActive(true);
            isPauseActive = false;
        }
        else
        {
            pausePanel.SetActive(false);
          
            isPauseActive = true;
        }
    }



    public void ExitButton()
    {
        ClosePanels();
        SceneManager.LoadScene("Menu");
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

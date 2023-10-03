using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public  GameObject[] Panels;




    //PauseButton
    public GameObject pausePanel;
    bool PauseButtonControl = true;


    private void Start()
    {
      

    }
    public void StartButton()//Hangi B�l�mde kald�ysa Ordan Ba�lat�r
    {

    }

    public void RestartButton()//O an ki oynanan B�l�m� yeniden ba�lat�r
    {
        ClosePanel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }
    
    public void PauseButton()//Oyunu Durdurur Pause Ekran�n� ��kart�r
    {
        if (PauseButtonControl == true)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("oyun durdu");
            PauseButtonControl = false;
            


        }
        else if (PauseButtonControl == false)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            
            Debug.Log("oyuna devamke");
            PauseButtonControl = true;
            

        }
   
        

    }

    public void MuteButton()//Oyunu sesini a�ar veya kapat�r
    {

    }

    public void LevelButton()//Hangi levele t�klarsa e�er kilitli de�ilse o leveli a�ar
    {

    }
    public void ExitButton()//Ana men�ye d�nd�r�r
    {
        ClosePanel();
        SceneManager.LoadScene("Menu");
    }
    public void QuitButton()//Oyunu tamamen kapat�r
    {

    }

    public void ClosePanel()
    {
        foreach (GameObject Panel in Panels)
        {
            if (Panel.activeSelf)
            {
                Panel.SetActive(false);
            }
        }

    }
    



}

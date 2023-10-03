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
    public void StartButton()//Hangi Bölümde kaldýysa Ordan Baþlatýr
    {

    }

    public void RestartButton()//O an ki oynanan Bölümü yeniden baþlatýr
    {
        ClosePanel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }
    
    public void PauseButton()//Oyunu Durdurur Pause Ekranýný Çýkartýr
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

    public void MuteButton()//Oyunu sesini açar veya kapatýr
    {

    }

    public void LevelButton()//Hangi levele týklarsa eðer kilitli deðilse o leveli açar
    {

    }
    public void ExitButton()//Ana menüye döndürür
    {
        ClosePanel();
        SceneManager.LoadScene("Menu");
    }
    public void QuitButton()//Oyunu tamamen kapatýr
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

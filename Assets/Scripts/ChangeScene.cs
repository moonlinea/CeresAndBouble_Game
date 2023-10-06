using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private LevelController levelController;
    public void SceneChange(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void StartBtn()
    {
        if (LevelController.playerLevel >= 0)
        {
            SceneManager.LoadScene(LevelController.playerLevel+2);
        }
        else SceneManager.LoadScene(LevelController.playerLevel);
            
            
        
    }
}

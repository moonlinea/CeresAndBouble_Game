using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private LevelController levelController;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartButton()
    {
        if (LevelController.PlayerLevel >= 0)
        {
            SceneManager.LoadScene(LevelController.PlayerLevel + 2);
        }
        else
        {
            SceneManager.LoadScene(LevelController.PlayerLevel);
        }
    }
}


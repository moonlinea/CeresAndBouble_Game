using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level[] levels; // Level nesnelerinin listesi
    [SerializeField] private Button[] levelButtons; // Level dü?melerinin listesi
    [SerializeField] private GameObject[] LevelsCards;
    //[SerializeField] private int levelsCardScene = 0;
    private int lastLevel;

    public static int PlayerLevel
    {
        get { return PlayerPrefs.GetInt("PlayerLevel", 1); }
        set { PlayerPrefs.SetInt("PlayerLevel", value); }
    }

    private void Start()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = i <= PlayerLevel;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        levels[levelIndex].Load();
    }

    public void ResetLevels()
    {
        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            PlayerLevel = 0;
        }
    }
    public void ChangeLevels(string isLeftOrRight)
    {
        if(isLeftOrRight== "left")
        {
            //LevelsCards(levelsCardScene).SetActive = true;
        }
    }
}



[System.Serializable]
public class Level
{
    public string levelName;
    public bool isUnlocked;

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public void Unlock()
    {
        isUnlocked = true;
    }

    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}

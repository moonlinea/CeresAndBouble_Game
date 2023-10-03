using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level[] levels; // Level nesnelerinin listesi
    [SerializeField] private Button[] levelButtons; // Level düðmelerinin listesi
    private int LastLevel;
    public static int playerLevel
    {
        get { return PlayerPrefs.GetInt("playerLevel", 1); }
        set { PlayerPrefs.SetInt("playerLevel", value); }
    }
  
     private void Start()
    {
        SetButtons();
    }

    void SetButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = i <= playerLevel;
        }
    }

    public void LoadLevel(int lv)
    {
        levels[lv].Load();
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

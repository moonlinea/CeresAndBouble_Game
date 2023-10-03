using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level[] levels; // Level nesnelerinin listesi
    [SerializeField] private Button[] levelButtons; // Level düðmelerinin listesi
    private int LastLevel;
  
     private void Start()
    {
        
        LastLevel = PlayerPrefs.GetInt("levelAt");
        // Tüm levelleri kontrol et
        LoadLevel();
    }

    public void LoadLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            
            if (i <= LastLevel)
            {
                UnlockLevel(i);
                levels[i].Unlock();

                // Level kilitli deðilse açýk hale getir
                if ((i <= LastLevel && levels[i].IsUnlocked()))
                {
                    levels[i].Unlock();
                    UpdateLevelButton(i);
                    // Level düðmesinin durumunu güncelle
                    for (int y = 1; y < levels.Length; y++)
                    {
                        levels[y].isUnlocked = false;
                        UpdateLevelButton(y);

                    }
                }
            }

        }
    }
    public void UnlockLevel(int levelIndex)
    {
        Debug.Log(levelIndex);
        Debug.Log(levels.Length);
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            levels[levelIndex].Unlock(); // Seviyenin kilidini aç

            UpdateLevelButton(levelIndex); // Level düðmesinin durumunu güncelle
        }
        else
        {
            Debug.LogError("Geçersiz level dizini: " + levelIndex);
        }
    }

    private void UpdateLevelButton(int LevelIndex)
    {
        if (LevelIndex >= 0 && LevelIndex <= levelButtons.Length)
        {
            Debug.Log("AÇIK OLAN BUTON" + LevelIndex);
            levelButtons[LevelIndex].interactable = levels[LevelIndex].IsUnlocked(); // Level düðmesinin durumunu güncelle
            
        }
        else
        {
            Debug.LogError("Geçersiz level dizini: " + LevelIndex);
        }
    }
    public void ResetLevels()
    {
        // Tüm seviyelerin kilidini kapat
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i].isUnlocked = false;
            UpdateLevelButton(i);
            PlayerPrefs.SetInt("levelAt", 0);
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
}

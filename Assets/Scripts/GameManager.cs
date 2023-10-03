using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        
        Debug.Log("---------MENÜDE SON KAYDEDÝLEN LEVEL"+(PlayerPrefs.GetInt("levelAt") - 1)  );
      
    }

   
}

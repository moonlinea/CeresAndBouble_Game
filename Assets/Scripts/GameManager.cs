using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        
        Debug.Log("---------MEN�DE SON KAYDED�LEN LEVEL"+(PlayerPrefs.GetInt("levelAt") - 1)  );
      
    }

   
}

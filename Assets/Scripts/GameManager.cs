using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool ofGravityScale;
    [SerializeField] public float scoreGold;
    [SerializeField] public float collectedItemCount;
    private LevelScoreCalculater scoreCalculater;
    private void Start()
    {
        scoreGold = 0;
        collectedItemCount = 0;
        
    }




    public void ScoreGoldCalculated()
    {
       scoreGold += 10;
    }
    public void ScoreItemCalculated()
    {
        collectedItemCount++;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreCalculater : MonoBehaviour
{
    private float scoreGold;
    public float scoreTime;
    private float collectedItemCount;
    private float remainingLife;

    private CollectItem collectItem;
    private Timer remainingTime;
  
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI[] scoreElementsText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreGold = gameManager.scoreGold;
        collectedItemCount = gameManager.collectedItemCount;
        Time.timeScale = 0f;

        remainingTime = FindObjectOfType<Timer>();
        scoreTime = remainingTime.CalculateSliderValue();

       
        remainingLife = PlayerLife.playerLife;
        
        TotalScoreCalculate();
    }
    //Life Gold Time Item TotalScore
    private void TotalScoreCalculate()
    {
       // string[] scoreLabels = { "Remaining Life", "Collected Gold", "Remaining Time", "Collected Item", "Total Score" };
        float[] scoreValues = { remainingLife, scoreGold, scoreTime, collectedItemCount, 0f };

        // Toplam puanı hesaplayıp diziye ekliyoruz
        scoreValues[4] = scoreGold + (collectedItemCount * 10) + (scoreTime) + (remainingLife * 10);

        // Her bir metin nesnesine değeri yazdırıyoruz
        for (int i = 0; i < scoreElementsText.Length; i++)
        {
            scoreElementsText[i].text =  ": " + Mathf.RoundToInt(scoreValues[i]).ToString();
        }


    }

}

using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour
{
    public TextMeshProUGUI[] userNameTexts;
    public TextMeshProUGUI[] highScoreTexts;
    private LeaderBoardController leaderBoardController;

  

    private void Start()
    {
        leaderBoardController = GetComponent<LeaderBoardController>();
        leaderBoardController.DownloadHighScore();
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            highScoreTexts[i].text = i + 1 + "Fetching...";
            userNameTexts[i].text = i + 1 + "Fetching...";
        }

    }

    public void OnHighScoresDownloaded(HighScore[] highScore)
    {
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            highScoreTexts[i].text = i + 1 + ".";
            userNameTexts[i].text = i + 1 + ".";

            if (highScore.Length > i)
            {
                highScoreTexts[i].text += highScore[i].userName;
                userNameTexts[i].text += highScore[i].score;
            }
        }
    }

    //private IEnumerator RefreshHighScore()
    //{
    //    while (true)
    //    {
           
    //        yield return new WaitForSeconds(30); // Refresh every 30 seconds
    //    }
    //}
}

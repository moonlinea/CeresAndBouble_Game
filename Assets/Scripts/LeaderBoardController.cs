using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoardController : MonoBehaviour
{
    const string privateCode = "Vg_bFQzbJUKe0aHjXZI-IwYc5MiRYdnUyX6LBRkE5TJg";
    const string publicCode = "65cb67668f40bbbdf003eca1";
    const string webURL = "http://dreamlo.com/lb/";

    public HighScore[] highScoreList;
    private DisplayHighScore displayHighScore;

    private void Start()
    {
        displayHighScore = GetComponent<DisplayHighScore>();
        StartCoroutine(UploadNewHighScore("Moonlinea", 100));
        StartCoroutine(UploadNewHighScore("Moonlinea1", 101));
        StartCoroutine(UploadNewHighScore("Moonlinea2", 102));
        StartCoroutine(UploadNewHighScore("Moonlinea3", 103));
        StartCoroutine(UploadNewHighScore("Moonlinea4", 104));
        StartCoroutine(UploadNewHighScore("Moonlinea5", 105));
        StartCoroutine(UploadNewHighScore("Moonlinea6", 106));
        StartCoroutine(UploadNewHighScore("Moonlinea7", 107));
        StartCoroutine(UploadNewHighScore("Moonlinea8", 108));
        StartCoroutine(UploadNewHighScore("Moonlinea9", 109));
        StartCoroutine(UploadNewHighScore("Moonlinea10", 110));
        StartCoroutine(UploadNewHighScore("Moonlinea11", 111));
    }

    public IEnumerator UploadNewHighScore(string userName, int score)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(userName) + "/" + score))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Upload successful");
                DownloadHighScore();
            }
            else
            {
                Debug.Log("Error uploading score: " + www.error);
            }
        }

        yield return new WaitForSeconds(1f); // Hızlı ardışık yüklemeleri önlemek için bir süre bekleyin
    }

    public void DownloadHighScore()
    {
        StartCoroutine(DownloadHighScoreFromDataBase());
    }

    private IEnumerator DownloadHighScoreFromDataBase()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Download successful");
                Debug.Log("LİDERLİKTEN GELDİ"+www.downloadHandler.text); // Liderlik tablosundan gelen veriyi konsola yazdır
                FormatHighScores(www.downloadHandler.text);
                displayHighScore.OnHighScoresDownloaded(highScoreList);
            }
            else
            {
                Debug.Log("Error downloading scores: " + www.error);
            }
        }
    }


    private void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScoreList = new HighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string userName = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoreList[i] = new HighScore(userName, score);
            Debug.Log(highScoreList[i].userName + ": " + highScoreList[i].score);
        }
    }
}

public struct HighScore
{
    public string userName;
    public int score;

    public HighScore(string userName, int score)
    {
        this.userName = userName;
        this.score = score;
    }
}


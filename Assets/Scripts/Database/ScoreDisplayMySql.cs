using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayMySql : MonoBehaviour
{
    [SerializeField]
    private string DownloadScoreURL = "http://www.oyunlaogreniyorum.com/muzikaletleri/DownloadScore.php";
    public EnYuksekPuan[] highScoreList;
    public GameObject HighScoreTextObject;
    TMP_Text HighScoreText;
    void Start()
    {
        HighScoreText = HighScoreTextObject.GetComponent<TMP_Text>();
        StartCoroutine(RefreshHighScores());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator RefreshHighScores()
    {
        while (true)
        {
            HighScoreText.text = null;
            StartCoroutine(ScoreDownload(PlayerPrefs.GetInt("Oyun")));
            yield return new WaitForSeconds(30);
        }
    }
    IEnumerator ScoreDownload(int oyun)
    {
        WWWForm downloadScoreForm = new WWWForm();
        downloadScoreForm.AddField("oyun", oyun);

        WWW veriGonder = new WWW(DownloadScoreURL, downloadScoreForm);
        yield return veriGonder;
        if (veriGonder.error==null)
        {
            var veriDizisi = veriGonder.text.Split('*');
            highScoreList = new EnYuksekPuan[veriDizisi.Length];
            for (int i = 0; i < veriDizisi.Length; i++)
            {
                var entryInfo = veriDizisi[i].Split('/');
                string username = entryInfo[0];
                int score = int.Parse(entryInfo[1]);
                highScoreList[i] = new EnYuksekPuan(username, score);
                Debug.Log(highScoreList[i].userName + ":" + highScoreList[i].score);
            }
            OnHighScoresDownloaded(highScoreList);
        }
        else
        {
            Debug.Log("Giriþ yapýlýrken bir sorun ile karþýlaþýldý! \nSorun sende deðil bende :')");
        }
    }
    public void OnHighScoresDownloaded(EnYuksekPuan[] highScores)
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            HighScoreText.text += (i + 1) + ". " + highScores[i].userName + " - " + highScores[i].score + "\n";
        }
    }
    public struct EnYuksekPuan
    {
        public string userName;
        public int score;
        public EnYuksekPuan(string userName, int score)
        {
            this.userName = userName;
            this.score = score;
        }
    }
}

using TMPro;
using UnityEngine;

public class HighScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    private void Start()
    {
        scoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void OnEnable()
    {
        OnChangeHighScore();
        Messenger.AddListener(EventKey.OnChangeHighScore, OnChangeHighScore);
    }

    private void OnChangeHighScore()
    {
        /*Debug.Log("Da cap nhat diem cao");
        if (ScoreManager.highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.highScore);
            scoreTxt.SetText(ScoreManager.highScore.ToString());
        }*/
        scoreTxt.SetText(PlayerPrefs.GetInt("HighScore").ToString());
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.OnChangeHighScore, OnChangeHighScore);
    }


    private void OnValidate()
    {
        scoreTxt = GetComponent<TextMeshProUGUI>();
    }
}

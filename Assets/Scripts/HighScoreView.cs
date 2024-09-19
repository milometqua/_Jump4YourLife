using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    private void Start()
    {
        scoreTxt.text = PlayerPrefs.GetInt("", 0).ToString();
    }
    private void OnEnable()
    {
        OnChangeHighScore();
        Messenger.AddListener(EventKey.OnChangeHighScore, OnChangeHighScore);
    }

    private void OnChangeHighScore()
    {
        Debug.Log("Da cap nhat diem cao");
        if (ScoreManager.Score > PlayerPrefs.GetInt(""))
        {
            //Debug.Log("Da cap nhat diem cao");
            PlayerPrefs.SetInt("", ScoreManager.Score);
            scoreTxt.SetText(ScoreManager.Score.ToString());
        }
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    private void OnEnable()
    {
        OnChangeScore();
        Messenger.AddListener(EventKey.OnChangeScore, OnChangeScore);
    }

    private void OnChangeScore()
    {
        scoreTxt.SetText(ScoreManager.Score.ToString());
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.OnChangeScore, OnChangeScore);
    }


    private void OnValidate()
    {
        scoreTxt = GetComponent<TextMeshProUGUI>();
    }
}

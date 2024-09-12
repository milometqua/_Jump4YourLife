using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = -1;
    [SerializeField] private TextMeshProUGUI ScoreText;
    void OnEnable()
    {
        Messenger.AddListener<float>(EventKey.UPDATE_UI, UpScore);
    }
    void OnDisable()
    {
        Messenger.RemoveListener<float>(EventKey.UPDATE_UI, UpScore); // Always remember to remove this listener
    }
    private void UpScore(float distance)
    {
        if(distance < -3f)
        {
            score += 2;
        }
        else
        {
            score += 1;
        }
        Debug.Log(score);
        ScoreText.text = score.ToString();
    }
}

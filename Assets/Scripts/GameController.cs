using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    //[SerializeField] private GameObject score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1.0f;
    }

    public void ShowScore(float distance)
    {
        Messenger.Broadcast<float>(EventKey.UPDATE_UI, distance);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
    }
}
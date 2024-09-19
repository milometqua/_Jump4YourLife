using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public static int Score;
    public static int highScore;
    private void Start()
    {
        SetScore(-1);
    }
    public static void AddScore(int amount)
    {
        Score += amount;
        Messenger.Broadcast(EventKey.OnChangeScore);
        Messenger.Broadcast(EventKey.OnChangeHighScore);
        Debug.Log("Da cong diem");
    }
    public static void SetScore(int value)
    {
        Score = value;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
}

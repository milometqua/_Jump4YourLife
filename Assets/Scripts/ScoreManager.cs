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
        //Messenger.Broadcast(EventKey.OnChangeHighScore); //không hợp lý, chỗ này có change highscore đâu mà phát event hả em,nên phát ra khi user đã endgame
        //Debug.Log("Da cong diem");
    }
    public static void SetScore(int value)
    {
        Score = value;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
}

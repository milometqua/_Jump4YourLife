using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton <GameController>
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void EndGame()
    {
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("GameOverPanel");
        //Messenger.Broadcast(EventKey.OnChangeHighScore);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("PlayScene");
        ScoreManager.Score = -1;
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ResetScene()
    {
        Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.Score = -1;
    }
}
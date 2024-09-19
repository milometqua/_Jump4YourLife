using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /*public void ShowScore(float distance)
    {
        Messenger.Broadcast<float>(EventKey.UPDATE_UI, distance);
    }*/

    public void EndGame()
    {
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("GameOverPanel");
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
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton <GameController>
{
    public GameObject perfect;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("PausePanel");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        PanelManager.Instance.CloseAll();
        /*PanelManager.Instance.ClosePanel("ShadePanel");
        PanelManager.Instance.ClosePanel("PausePanel");*/
    }
    public void EndGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOver);
        ScoreManager.UpdateHighScore();
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("GameOverPanel");
        ScoreManager.Score = -1;
    }

    public void OpenSettingPanel()
    {
        PanelManager.Instance.OpenPanel("SettingPanel");
    }

    public void OpenShopPanel()
    {
        PanelManager.Instance.OpenPanel("ShopPanel");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("PlayScene");
        ScoreManager.Score = -1;
    }
    public void LoadMenuScene()
    {
        ScoreManager.UpdateHighScore();
        Messenger.Broadcast(EventKey.OnChangeHighScore);
        SceneManager.LoadScene("MenuScene");
    }
    public void ResetScene()
    {
        Debug.Log("Reset");
        ScoreManager.UpdateHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.Score = -1;
    }

    public void OnPerfect()
    {
        perfect.SetActive(true);
    }

    public void OffPerfect()
    {
        perfect.SetActive(false);
    }
}
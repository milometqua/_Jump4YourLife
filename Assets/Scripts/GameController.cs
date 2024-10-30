using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton <GameController>
{
    public GameObject perfect;
    public GameObject taptap;
    public GameObject countdown;

    private Animator animatorCountdown;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        OffCountdown();
        OffPerfect();
        animatorCountdown = countdown.GetComponent<Animator>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("PausePanel");
    }

    public void ContinueGame()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        OnCountdown();
        animatorCountdown.updateMode = AnimatorUpdateMode.UnscaledTime;
        animatorCountdown.Play("Countdown");
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1.0f;
        OffCountdown();
    }
    public void EndGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOver);
        ScoreManager.UpdateHighScore();
        Time.timeScale = 0f;
        PanelManager.Instance.OpenPanel("ShadePanel");
        PanelManager.Instance.OpenPanel("GameOverPanel");
        ScoreManager.Score = 0;
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
        SceneManager.LoadScene("PlayScene");
        ScoreManager.Score = 0;
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
        ScoreManager.Score = 0;
    }

    public void OnPerfect()
    {
        perfect.SetActive(true);
    }

    public void OffPerfect()
    {
        perfect.SetActive(false);
    }

    public void OnTap()
    {
        taptap.SetActive(true);
    }

    public void OffTap()
    {
        taptap.SetActive(false);
    }

    public void OnCountdown()
    {
        countdown.SetActive(true);
    }

    public void OffCountdown()
    {
        countdown.SetActive(false);
    }
}
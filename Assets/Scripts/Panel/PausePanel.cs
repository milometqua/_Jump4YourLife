using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : Panel
{
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite SFXOff;
    [SerializeField] private Sprite SFXOn;
    [SerializeField] private Image musicBtn;
    [SerializeField] private Image SFXBtn;

    private int isMusicPlaying;
    private int isSFXPlaying;

    #region SingleTon
    public static PausePanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        isMusicPlaying = PlayerPrefs.GetInt("IsMusicPlaying", 1);
        isSFXPlaying = PlayerPrefs.GetInt("IsSFXPlaying", 1);
        Init();
    }

    private void Init()
    {
        if (PlayerPrefs.GetInt("IsMusicPlaying") == 1)
        {
            musicBtn.sprite = musicOn;
            AudioManager.Instance.TurnOnMusic();
        }
        else
        {
            musicBtn.sprite = musicOff;
            AudioManager.Instance.TurnOffMusic();
        }
        if (PlayerPrefs.GetInt("IsSFXPlaying") == 1)
        {
            SFXBtn.sprite = SFXOn;
            AudioManager.Instance.TurnOnSFX();
        }
        else
        {
            SFXBtn.sprite = SFXOff;
            AudioManager.Instance.TurnOffSFX();
        }
    }

    public void ContinueGame()
    {
        GameController.Instance.ContinueGame();
        PanelManager.Instance.CloseAll();
        //StartCoroutine(Countdown());
        //Time.timeScale = 1.0f;
    }
    public void LoadMenuScene()
    {
        GameController.Instance.LoadMenuScene();
    }

    public void ReloadScene()
    {
        GameController.Instance.ResetScene();
    }

    public void ToggleTheMusic()
    {
        if (isMusicPlaying == 0)
        {
            isMusicPlaying = 1;
            musicBtn.sprite = musicOn;
            AudioManager.Instance.TurnOnMusic();

        }
        else
        {
            isMusicPlaying = 0;
            musicBtn.sprite = musicOff;
            AudioManager.Instance.TurnOffMusic();
        }
        PlayerPrefs.SetInt("IsMusicPlaying", isMusicPlaying);
        PlayerPrefs.Save();
    }

    public void ToggleTheSFX()
    {
        if (isSFXPlaying == 0)
        {
            isSFXPlaying = 1;
            SFXBtn.sprite = SFXOn;
            AudioManager.Instance.TurnOnSFX();

        }
        else
        {
            isSFXPlaying = 0;
            SFXBtn.sprite = SFXOff;
            AudioManager.Instance.TurnOffSFX();
        }
        PlayerPrefs.SetInt("IsSFXPlaying", isSFXPlaying);
        PlayerPrefs.Save();
    }
}

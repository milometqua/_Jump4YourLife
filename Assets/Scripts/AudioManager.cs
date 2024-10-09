using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip breakSound;
    public AudioClip gameOver;
    public AudioClip jump;

    private void Start()
    {
        musicSource.loop = true;
        musicSource.clip = background;
        musicSource.Play();
        if(PlayerPrefs.GetInt("IsMusicPlaying") == 1)
        {
            TurnOnMusic();
        }
        else
        {
            TurnOffMusic();
        }
        if (PlayerPrefs.GetInt("IsSFXPlaying") == 1)
        {
            TurnOnSFX();
        }
        else
        {
            TurnOffSFX();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
         SFXSource.PlayOneShot(clip);
    }

    public void TurnOnMusic()
    {
        musicSource.mute = false;
    }

    public void TurnOffMusic()
    {
        musicSource.mute = true;
    }

    public void TurnOnSFX()
    {
        SFXSource.mute = false;
    }

    public void TurnOffSFX()
    {
        SFXSource.mute = true;
    }
}

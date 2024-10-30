using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    #region SingleTon
    public static ShopPanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [Header("Player")]
    public Image player;
    public GameObject playerPrefab;
    public Transform contentPlayer;
    private int idSelectingPlayer;
    public TextMeshProUGUI namePlayer;

    [Header("Background")]
    public GameObject bgPrefab;
    public Transform contentBg;
    private int idSelectingBg;
    private List<GameObject> _bgPrefabs = new List<GameObject>();


    [SerializeField] private GameObject BackgroundView;
    [SerializeField] private GameObject PlayerView;
    [SerializeField] private RectTransform contentRectTransform;
    [SerializeField] private GameObject chooseBg;
    [SerializeField] private GameObject choosePlayer;

    private void Start()
    {
        LoadCurrentAvatar();
        GenerateAvatar();
        GenerateBg();
        LoadCurrentBg();
    }
    public void OpenScrollBg()
    {
        BackgroundView.SetActive(true);
        PlayerView.SetActive(false);
        chooseBg.SetActive(true);
        choosePlayer.SetActive(false);
    }

    public void OpenScrollPlayer()
    {
        PlayerView.SetActive(true);
        BackgroundView.SetActive(false);
        chooseBg.SetActive(false);
        choosePlayer.SetActive(true);
        SetContentPosY(0);
    }

    public override void Close()
    {
        base.Close();
        BackgroundView.SetActive(true);
        PlayerView.SetActive(false);
        chooseBg.SetActive(true);
        choosePlayer.SetActive(false);
    }

    private void LoadCurrentAvatar()
    {
        idSelectingPlayer = PlayerPrefs.GetInt("PlayerId", 1);
        Debug.Log(idSelectingPlayer);
        PlayerInfors playerInfors = Resources.Load<PlayerInfors>("Player/" + idSelectingPlayer);
        player.sprite = playerInfors.SpriteImage;
        namePlayer.SetText(playerInfors.NamePlayer);
    }

    private void LoadCurrentBg()
    {
        idSelectingBg = PlayerPrefs.GetInt("BackgroundId", 1);
        Debug.Log(idSelectingBg);
        BackgroundInfos backgroundInfors = Resources.Load<BackgroundInfos>("Backgrounds/" + idSelectingBg);
        //player.sprite = playerInfors.SpriteImage;
    }

    private void GenerateAvatar()
    {
        PlayerInfors[] playerLists = Resources.LoadAll<PlayerInfors>("Player");
        Debug.Log(playerLists.Length);
        foreach (PlayerInfors player in playerLists)
        {
            var obj = Instantiate(playerPrefab, contentPlayer);
            obj.GetComponent<PlayerButton>().Init(player);
            Debug.Log(player.name);
        }
    }

    private void GenerateBg()
    {
        BackgroundInfos[] bgLists = Resources.LoadAll<BackgroundInfos>("Backgrounds");
        Debug.Log(bgLists.Length);
        foreach (BackgroundInfos background in bgLists)
        {
            var obj = Instantiate(bgPrefab, contentBg);
            obj.GetComponent<BackgroundButton>().Init(background);
            _bgPrefabs.Add(obj);
        }
    }
    private void SetContentPosY(float newY)
    {
        Vector2 newPosition = contentRectTransform.anchoredPosition;
        newPosition.y = newY;
        contentRectTransform.anchoredPosition = newPosition;
    }

    public void ChangePlayer(PlayerInfors playerInfors)
    {
        idSelectingPlayer = playerInfors.Id;
        player.sprite = playerInfors.SpriteImage;
        namePlayer.text = playerInfors.NamePlayer;
        PlayerPrefs.SetInt("PlayerId", idSelectingPlayer);
    }

    public void SetOriginBtn()
    {
        foreach (GameObject theme in _bgPrefabs)
        {
            BackgroundInfos obj = theme.GetComponent<BackgroundButton>().backgroundInfos;
            if (PlayerPrefs.GetInt("BackgroundId").Equals(obj.Id))
            {
                theme.GetComponent<BackgroundButton>().SetBtnUnselected();
                break;
            }
        }
    }

    public void ChangeBackground(BackgroundInfos backgroundInfos)
    {
        idSelectingBg = backgroundInfos.Id;
        PlayerPrefs.SetInt("BackgroundId", idSelectingBg);
        //background.sprite = backgroundInfos.BackgroundIcon;
    }
}

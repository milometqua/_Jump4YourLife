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

    public Image player;
    public GameObject playerPrefab;
    public Transform content;
    private int idSelecting;
    public TextMeshProUGUI namePlayer;

    [SerializeField] private GameObject BackgroundView;
    [SerializeField] private GameObject PlayerView;
    [SerializeField] private RectTransform contentRectTransform;

    public void OpenScrollBg()
    {
        BackgroundView.SetActive(true);
        PlayerView.SetActive(false);
    }

    public void OpenScrollPlayer()
    {
        PlayerView.SetActive(true);
        BackgroundView.SetActive(false);
        SetContentPosY(0);
    }

    public override void Close()
    {
        base.Close();
        BackgroundView.SetActive(true);
        PlayerView.SetActive(false);
    }

    private void Start()
    {
        LoadCurrentAvatar();
        GenerateAvatar();
    }
    private void LoadCurrentAvatar()
    {
        idSelecting = PlayerPrefs.GetInt("PlayerId", 5);
        Debug.Log(idSelecting);
        PlayerInfors playerInfors = Resources.Load<PlayerInfors>("Player/" + idSelecting);
        player.sprite = playerInfors.SpriteImage;

    }

    private void GenerateAvatar()
    {
        PlayerInfors[] playerLists = Resources.LoadAll<PlayerInfors>("Player");
        Debug.Log(playerLists.Length);
        foreach (PlayerInfors player in playerLists)
        {
            var obj = Instantiate(playerPrefab, content);
            obj.GetComponent<PlayerButton>().Init(player);
            Debug.Log(player.name);
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
        idSelecting = playerInfors.Id;
        player.sprite = playerInfors.SpriteImage;
        namePlayer.text = playerInfors.NamePlayer;
    }
}

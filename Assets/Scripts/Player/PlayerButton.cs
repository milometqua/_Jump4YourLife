using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] private Image preview;
    private string playerName;
    private PlayerInfors playerInfors;

    public void Init(PlayerInfors player)
    {
        playerInfors = player;

        preview.sprite = playerInfors.SpriteImageView;

        playerName = playerInfors.NamePlayer;
    }
    public void OnClick()
    {
        ShopPanel.Instance.ChangePlayer(playerInfors);
    }
}

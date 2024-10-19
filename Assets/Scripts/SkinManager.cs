using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private GameObject firstBase;
    public static GameObject obj;

    private void Start()
    {
        int idBg = PlayerPrefs.GetInt("BackgroundId");
        int idPlayer = PlayerPrefs.GetInt("PlayerId");
        background.sprite = Resources.Load<BackgroundInfos>("Backgrounds/" + idBg).Background;
        firstBase.GetComponent<SpriteRenderer>().sprite = Resources.Load<BackgroundInfos>("Backgrounds/" + idBg).Bases;
        obj = Resources.Load<PlayerInfors>("Player/" + idPlayer).Player;
        Instantiate(obj);
    }
}

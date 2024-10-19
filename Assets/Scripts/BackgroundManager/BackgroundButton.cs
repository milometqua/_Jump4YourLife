using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButton : MonoBehaviour
{
    [SerializeField] private Image preview;
    private BackgroundInfos backgroundInfos;

    public void Init(BackgroundInfos bg)
    {
        backgroundInfos = bg;
        preview.sprite = backgroundInfos.BackgroundIcon;
    }
    public void OnClick()
    {
        ShopPanel.Instance.ChangeBackground(backgroundInfos);
    }
}

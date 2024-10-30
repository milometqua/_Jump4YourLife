using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButton : MonoBehaviour
{
    [SerializeField] private Image preview;
    [SerializeField] private Image selectedTick;

    public BackgroundInfos backgroundInfos;

    public void Init(BackgroundInfos bg)
    {
        backgroundInfos = bg;
        preview.sprite = backgroundInfos.BackgroundIcon;
        if(PlayerPrefs.GetInt("BackgroundId") == backgroundInfos.Id)
        {
            SetBtnSelected();
        }
    }
    public void OnClick()
    {
        ShopPanel.Instance.SetOriginBtn();
        SetBtnSelected();
        ShopPanel.Instance.ChangeBackground(backgroundInfos);
    }
    public void SetBtnSelected()
    {
        selectedTick.gameObject.SetActive(true);
    }
    public void SetBtnUnselected()
    {
        selectedTick.gameObject.SetActive(false);
    }
}

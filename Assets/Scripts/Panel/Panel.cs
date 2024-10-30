using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool destroyOnClose = true;
    public virtual void Open()
    {
        gameObject.SetActive(true);
        //gameObject.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
        if (destroyOnClose)
        {
            PanelManager.Instance.RemovePanel(name);
            Destroy(gameObject);
        }
    }
}

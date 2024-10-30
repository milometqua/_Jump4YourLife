using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPanel : MonoBehaviour
{
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void OpenPanel()
    {
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }

    public void ClosePanel()
    {
        transform.DOScale(0f, 1f).SetEase(Ease.InBounce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

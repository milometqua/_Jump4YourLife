using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    [ContextMenu("Run")]
    private void CanMove()
    {
        if (transform.position.x >= 1.62f)
        {
            transform.DOMoveX(-1.62f, 2f).SetEase(Ease.Linear).SetLoops(5, LoopType.Yoyo).OnComplete(Fade);
        }
        else if (transform.position.x <= -1.62f)
        {
            transform.DOMoveX(1.62f, 2f).SetEase(Ease.Linear).SetLoops(5, LoopType.Yoyo).OnComplete(Fade);
        }
        
        //transform.DOMoveY(transform.position.y - 2f, 2f).SetEase(Ease.OutBounce);
    }

    [ContextMenu("Fade")]
    private void Fade()
    {
        if (spriteRenderer.color.a >= 1f)
        {
            spriteRenderer.DOFade(0f, 1f);
        }
        else if(spriteRenderer.color.a <= 0f)
        {
            spriteRenderer.DOFade(1f, 1f);
        }
    }

    private void Update()
    {
        //Fade();
        //CanMove();
    }

}

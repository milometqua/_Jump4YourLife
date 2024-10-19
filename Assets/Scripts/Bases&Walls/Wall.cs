using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        int id = PlayerPrefs.GetInt("BackgroundId");
        spriteRenderer.sprite = Resources.Load<BackgroundInfos>("Backgrounds/" + id).Wall;
    }
}

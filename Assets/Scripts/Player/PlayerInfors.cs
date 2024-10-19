using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayer", menuName = "PlayerInfors/Player", order = 1)]
public class PlayerInfors : ScriptableObject
{
    [SerializeField] private Sprite spriteImage;
    [SerializeField] private Sprite spriteImageView;
    [SerializeField] private GameObject player;
    [SerializeField] private int id;
    [SerializeField] private string namePlayer;

    public Sprite SpriteImage
    {
        get { return spriteImage; }
    }

    public Sprite SpriteImageView
    {
        get { return spriteImageView; }
    }
    public int Id
    {
        get { return id; }
    }

    public string NamePlayer
    {
        get { return namePlayer; }
    }

    public GameObject Player
    {
        get { return player; }
    }
    private void OnValidate()
    {
        id = int.Parse(name);
    }
}


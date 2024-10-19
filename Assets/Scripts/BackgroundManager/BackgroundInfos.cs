using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBackground", menuName = "BackgroundInfors/Background", order = 1)]
public class BackgroundInfos : ScriptableObject
{
    [SerializeField] private Sprite backgroundIcon;
    [SerializeField] private Sprite background;
    [SerializeField] private Sprite bases;
    [SerializeField] private Sprite breakBases;
    [SerializeField] private Sprite wall;
    [SerializeField] private int id;
    
    public Sprite BackgroundIcon
    {
        get { return backgroundIcon; }
    }

    public Sprite Background
    {
        get { return background; }
    }

    public Sprite Bases
    {
        get { return bases; }
    }

    public Sprite BreakBases
    {
        get { return breakBases; }
    }

    public int Id
    {
        get { return id; }
    }

    public Sprite Wall
    {
        get { return wall; }
    }
    private void OnValidate()
    {
        id = int.Parse(name);
    }
}

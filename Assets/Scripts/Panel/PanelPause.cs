using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPause : Panel
{
    public override void Open()
    {
        base.Open();
        Time.timeScale = 0f;
    }
    public override void Close()
    {
        base.Close();
        Time.timeScale = 1f;
    }
}

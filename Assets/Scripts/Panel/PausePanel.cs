using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Panel
{
    #region SingleTon
    public static PausePanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        PanelManager.Instance.CloseAll();
    }
}

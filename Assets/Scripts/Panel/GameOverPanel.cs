using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverPanel : Panel
{
    #region SingleTon
    public static GameOverPanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public void OnClickRestartBtn()
    {
        GameController.Instance.ResetScene();
    }    
}

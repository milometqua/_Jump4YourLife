using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelGameOver : Panel
{ 
    public void OnClickRestartBtn()
    {
        GameController.instance.ResetScene();
    }    
}

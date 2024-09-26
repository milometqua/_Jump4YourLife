using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelGameOver : Panel // mỗi panel lại đặt tên cấu trúc từ khác nhau vậy em, đặt theo tiếng anh thì mình để "Panel" ở cuối 
{ 
    public void OnClickRestartBtn()
    {
        GameController.Instance.ResetScene();
    }    
}

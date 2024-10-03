using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : Panel
{
    public void CloseSettingPanel()
    {
        PanelManager.Instance.CloseAll();
    }
}

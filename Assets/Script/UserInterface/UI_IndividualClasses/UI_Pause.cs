using System;
using UDCJ;
using UnityEngine;

public class UI_Pause : UI_Base
{
    private void Awake()
    {
        base.CurrentUIType = UIType.PauseUI;
    }
}

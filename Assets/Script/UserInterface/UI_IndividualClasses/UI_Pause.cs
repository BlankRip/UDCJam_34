using System;
using UnityEngine;

namespace UDCJ
{
    public class UI_Pause : UI_Base
    {
        private void Awake()
        {
            base.CurrentUIType = UIType.PauseUI;
        }
    }
}
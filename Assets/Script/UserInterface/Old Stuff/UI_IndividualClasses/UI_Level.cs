using UnityEngine;

namespace UDCJ
{
    public class UI_Level : UI_Base
    {
        private void Awake()
        {
            base.CurrentUIType = UIType.LevelUI;
        }
    }
}
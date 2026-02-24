using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace UDCJ
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIDataSO uiDataSO;

        public List<UI_Base> currentActiveUIObjects { get; private set; }

        private void Start()
        {
            currentActiveUIObjects = new List<UI_Base>();
        }

        public void EnableUI(UIType uiType)
        {
            switch (uiType)
            {
                case UIType.None:
                    return;
                case UIType.MainMenuUI:
                    AddToCurrentActiveUIObject(uiDataSO.UI_MainMenuCanvas);
                    break;
                case UIType.LevelUI:
                    AddToCurrentActiveUIObject(uiDataSO.UI_LevelCanvas);
                    break;
                case UIType.PauseUI:
                    AddToCurrentActiveUIObject(uiDataSO.UI_PauseCanvas);
                    break;
                case UIType.EndUI:
                    AddToCurrentActiveUIObject(uiDataSO.UI_EndCanvas);
                    break;
                default:
                    return;
            }
        }

        public void DisableUI(UIType uiType)
        {
            if (currentActiveUIObjects != null && currentActiveUIObjects.Count > 0)
            {
                foreach (UI_Base ui in currentActiveUIObjects)
                {
                    if (ui.CurrentUIType == uiType)
                    {
                        ui.gameObject.SetActive(false);
                    }
                }
            }
        }

        #region Helpers

        private void AddToCurrentActiveUIObject(UI_Base uiToAdd)
        {
            if (!currentActiveUIObjects.Any(ui => ui.CurrentUIType == uiToAdd.CurrentUIType))
            {
                UI_Base newUIBase = Instantiate(uiToAdd.gameObject).GetComponent<UI_Base>();
                if (newUIBase != null)
                {
                    currentActiveUIObjects.Add(newUIBase);
                }
            }
            else
            {
                foreach (UI_Base ui in currentActiveUIObjects)
                {
                    if (ui.CurrentUIType == uiToAdd.CurrentUIType && !ui.gameObject.activeInHierarchy)
                    {
                        ui.gameObject.SetActive(true);
                    }
                }
            }
        }

        #endregion
    }
}
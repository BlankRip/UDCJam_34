using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UDCJ
{
    public class InGameHUD : MonoBehaviour
    {
        [SerializeField]
        private Button reloadLevelButton;

        private void Start()
        {
            reloadLevelButton.onClick.AddListener(ReloadLevel);
        }

        private void OnDestroy()
        {
            reloadLevelButton.onClick.RemoveListener(ReloadLevel);
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

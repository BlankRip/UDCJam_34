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
        [SerializeField]
        private Button returnToMainMenuButton;

        private void Start()
        {
            reloadLevelButton.onClick.AddListener(ReloadLevel);
            returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        private void OnDestroy()
        {
            reloadLevelButton.onClick.RemoveListener(ReloadLevel);
            returnToMainMenuButton.onClick.RemoveListener(ReturnToMainMenu);
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void ReturnToMainMenu()
        {
            SceneManager.LoadScene(GameStatics.MainMenuSceneBuildIndex);
        }
    }
}

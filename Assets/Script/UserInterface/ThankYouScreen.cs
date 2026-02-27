using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UDCJ
{
    public class ThankYouScreen : MonoBehaviour
    {
        [SerializeField]
        private Button mainMenuButton;

        private void Start()
        {
            mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(GameStatics.MainMenuSceneBuildIndex));
        }

        private void OnDestroy()
        {
            mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}

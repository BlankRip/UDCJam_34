using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UDCJ
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField]
        private Button newGameButton;
        [SerializeField]
        private Button continueGameButton;
        [SerializeField]
        private Button levelSelectButton;
        [SerializeField] 
        private Button quitButton;

        [Space] [Space] [SerializeField] 
        private GameObject levelSelectPanel;
        
        private int lastPlayedLevelBuildIndex = -1;

        private void Start()
        {
            if (!PlayerPrefs.HasKey(GameStatics.UnlockedLevelsId))
            {
                PlayerPrefs.SetInt(GameStatics.UnlockedLevelsId, 0);
            }
            if (!PlayerPrefs.HasKey(GameStatics.LastPlayedLevelId))
            {
                PlayerPrefs.SetInt(GameStatics.LastPlayedLevelId, 0);
            }

            lastPlayedLevelBuildIndex = PlayerPrefs.GetInt(GameStatics.LastPlayedLevelId);
            if (lastPlayedLevelBuildIndex <= 0)
            {
                continueGameButton.interactable = false;
            }
            if (PlayerPrefs.GetInt(GameStatics.UnlockedLevelsId) <= 0)
            {
                levelSelectButton.interactable = false;
            }
            
            newGameButton.onClick.AddListener(OnNewGameClicked);
            continueGameButton.onClick.AddListener(OnContinueGameClicked);
            levelSelectButton.onClick.AddListener(OnLevelSelectClicked);
            quitButton.onClick.AddListener(OnQuitClicked);
        }

        private void OnDestroy()
        {
            newGameButton.onClick.RemoveListener(OnNewGameClicked);
            continueGameButton.onClick.RemoveListener(OnContinueGameClicked);
            levelSelectButton.onClick.RemoveListener(OnLevelSelectClicked);
            quitButton.onClick.RemoveListener(OnQuitClicked);
        }

        private void OnNewGameClicked()
        {
            SceneManager.LoadScene(GameStatics.Level1SceneBuildIndex);
        }

        private void OnContinueGameClicked()
        {
            SceneManager.LoadScene(lastPlayedLevelBuildIndex);
        }

        private void OnLevelSelectClicked()
        {
            levelSelectPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }
    }
}

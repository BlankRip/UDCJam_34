using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UDCJ
{
    public class LevelSelectPanel : MonoBehaviour
    {
        [SerializeField] 
        private Button backButton;
        [SerializeField] 
        private GameObject mainMenuPanel;
        
        [Space][Space]
        [SerializeField] 
        private LevelSelectButton levelSelectButtonPrefab;
        [SerializeField] 
        private Transform buttonsHolderTransform;
        
        private int unlockdedLevelsCount;

        private void Start()
        {
            unlockdedLevelsCount = PlayerPrefs.GetInt(GameStatics.UnlockedLevelsId);
            for (int i = 0; i < unlockdedLevelsCount; i++)
            {
                LevelSelectButton spawnedButton = Instantiate(levelSelectButtonPrefab, buttonsHolderTransform);
                spawnedButton.SetUpButton(GameStatics.Level1SceneBuildIndex + i);
            }
            
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDestroy()
        {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            mainMenuPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace UDCJ
{
    public class UI_MainMenu : UI_Base
    {
        [Header("UI Panel References")]
        [SerializeField] private GameObject basePanel;
        [SerializeField] private GameObject optionsPanel;
        [SerializeField] private GameObject audioSettingsPanel;

        [Header("Base Panel References")]
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button exitButton;

        [Header("Options Panel References")] 
        [SerializeField] private Button displaySettingsButton;
        [SerializeField] private Button audioSettingsButton;
        [SerializeField] private Button creditsButton;
        
        [Header("Audio Settings Panel References")]
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        
        [Header("Other UI Referecnes")]
        [SerializeField] private Button universalReturnButton;

        private GameObject currentActivePanel;
        
        private void Awake()
        {
            base.CurrentUIType = UIType.MainMenuUI;
        }

        private void Start()
        {
            if (basePanel != null && optionsPanel != null && audioSettingsPanel != null)
            {
                basePanel.SetActive(true);
                optionsPanel.SetActive(false);
                audioSettingsPanel.SetActive(false);
            }
        }
    }
}
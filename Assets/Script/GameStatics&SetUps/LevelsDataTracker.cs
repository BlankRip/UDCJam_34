using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UDCJ
{
    public class LevelsDataTracker : MonoBehaviour
    {
        [SerializeField] 
        private int currentLevel = 1;

        private void Start()
        {
            PlayerPrefs.SetInt(GameStatics.LastPlayedLevelId, SceneManager.GetActiveScene().buildIndex);

            int unlockdeLevelsCount = PlayerPrefs.GetInt(GameStatics.UnlockedLevelsId);
            if (currentLevel > unlockdeLevelsCount)
            {
                PlayerPrefs.SetInt(GameStatics.UnlockedLevelsId, currentLevel);
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                PlayerPrefs.DeleteKey(GameStatics.UnlockedLevelsId);
                PlayerPrefs.DeleteKey(GameStatics.LastPlayedLevelId);
            }
        }
#endif
    }
}

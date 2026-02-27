using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UDCJ
{
    public class LevelSelectButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private Button button;
        private int connectedSceneBuildIndex;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            SceneManager.LoadScene(connectedSceneBuildIndex);
        }

        public void SetUpButton(int levelBuildIndex)
        {
            connectedSceneBuildIndex = levelBuildIndex;
            text.text = levelBuildIndex.ToString();
        }
    }
}
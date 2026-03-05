using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UDCJ
{
    public class AudioSettingsSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup mainMixerGroup;
        
        private Slider slider;
        private static string VolumePlayerPrefKey = "MasterVolume";

        private void Start()
        {
            slider = GetComponent<Slider>();
            if (slider == null)
            {
                Debug.LogError("Audio Settings Slider script is added to a non slider game object, destroying self", gameObject);
            }

            if (!PlayerPrefs.HasKey(VolumePlayerPrefKey))
                PlayerPrefs.SetFloat(VolumePlayerPrefKey, 1f);
            
            slider.value = PlayerPrefs.GetFloat(VolumePlayerPrefKey);
            SetVolume(slider.value);
            slider.onValueChanged.AddListener(SetVolume);
        }

        private void OnDestroy()
        {
            slider?.onValueChanged.RemoveListener(SetVolume);
        }

        private void SetVolume(float currentValue)
        {
            float currentMasterVolume = Mathf.Lerp(-35.0f, 0.0f, currentValue);
            if(currentValue == 0.0f) 
                currentMasterVolume = -80.0f;
            mainMixerGroup.audioMixer.SetFloat("MasterVolume", currentMasterVolume);
            
            PlayerPrefs.SetFloat(VolumePlayerPrefKey, currentValue);
        }
    }
}

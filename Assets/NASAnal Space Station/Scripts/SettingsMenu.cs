namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;

    public class SettingsMenu : MonoBehaviour
    {
        // reerence to audio mixer
        public AudioMixer audioMixer;

        public void SetVolume(float volume)
        {
            // edits the value of volume in the main mixer
            audioMixer.SetFloat("volume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            // Adjusts grphics quality
            QualitySettings.SetQualityLevel(qualityIndex);
        }
    }
}
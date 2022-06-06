namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;

    public class SettingsApplier : MonoBehaviour
    {
        #region Fields

        // variables
        // variable to check for an instance of this object
        public static SettingsApplier instance;

        // variables to store settings values
        // othewr settings
        public int setResIndex;
        public int setQualityIndex;

        // volume settings
        public float setVolume;
        public float setBGMvol;
        public float setSFXvol;

        // reference to0 audiomixer
        public AudioMixer audioMixer;

        Resolution[] resolutions;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // checks if their is another settings applier
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // does not get destroyed when loading new scene.
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            // set values
            PlayerPrefs.GetInt("ResIndex", setResIndex);
            PlayerPrefs.GetInt("Quality", setQualityIndex);
            PlayerPrefs.GetFloat("volume", setVolume);
            PlayerPrefs.GetFloat("BGMvolume", setBGMvol);
            PlayerPrefs.GetFloat("SFXvolume", setSFXvol);
            
            // Call functions

        }

        #endregion

        #region Methods

        public void SetResolution(int resolutionIndex)
        {
            // using the resolution index set in dropdown, look for the resolution to set to this variable resolution
            Resolution resolution = resolutions[resolutionIndex];

            // sets the resolution
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            // store value ion player prefs
            PlayerPrefs.SetInt("ResIndex", resolutionIndex);
        }

        public void SetVolume(float volume)
        {
            // edits the value of volume in the main mixer e.g Master
            audioMixer.SetFloat("volume", volume);

            // store value in player prefs
            PlayerPrefs.SetFloat("Volume", volume);
        }

        public void SetBGMVolume(float volume)
        {
            // edits the value of volume for BGM in mainh mixer
            audioMixer.SetFloat("BGMvolume", volume);

            // store value in player prefs
            PlayerPrefs.SetFloat("BGMvolume", volume);
        }

        public void SetSFXVolume(float volume)
        {
            // edits the value of volume for SFX in mainh mixer
            audioMixer.SetFloat("SFXvolume", volume);

            // store value in player prefs
            PlayerPrefs.SetFloat("SFXvolume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            // Adjusts grphics quality
            QualitySettings.SetQualityLevel(qualityIndex);

            // store value ion player prefs
            PlayerPrefs.SetInt("Quality", qualityIndex);
        }

        #endregion
    }
}
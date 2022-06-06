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
        // other settings
        public int setResIndex;
        public int setQualityIndex;
        public bool setFullscreen;

        // volume settings
        public float setVolume;
        public float setBGMvol;
        public float setSFXvol;

        // int for fullscreen
        public int fullscreenStat;

        // other variables
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

            // collect resolution option in list/array
            resolutions = Screen.resolutions;

            // variable that holds the index of current resolution
            int currentResolutionIndex = 0;

            // loop through each element is our resolutions array
            for (int i = 0; i < resolutions.Length; i++)
            {
                // looks for the current resolution of screen/window
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    // sets current resolution idex for display
                    currentResolutionIndex = i;
                }
            }
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
            PlayerPrefs.GetInt("FullscreenStat", fullscreenStat);

            // call conversion function
            setFullscreen = intTobool(fullscreenStat);

            // Call functions to apply settings
            SetResolution(setResIndex);
            SetQuality(setQualityIndex);
            SetVolume(setVolume);
            SetBGMVolume(setBGMvol);
            SetSFXVolume(setSFXvol);
            SetFullscreen(setFullscreen);
        }

        #endregion

        #region Methods

        public void SetResolution(int resolutionIndex)
        {
            // using the resolution index, look for the resolution to set to this variable resolution
            Resolution resolution = resolutions[resolutionIndex];

            // sets the resolution
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetVolume(float volume)
        {
            // edits the value of volume in the main mixer e.g Master
            audioMixer.SetFloat("volume", volume);
        }

        public void SetBGMVolume(float volume)
        {
            // edits the value of volume for BGM in mainh mixer
            audioMixer.SetFloat("BGMvolume", volume);
        }

        public void SetSFXVolume(float volume)
        {
            // edits the value of volume for SFX in mainh mixer
            audioMixer.SetFloat("SFXvolume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            // Adjusts grphics quality
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            // turns on or off fullscreen
            Screen.fullScreen = isFullscreen;
        }

        bool intTobool(int val)
        {
            if (val != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            #endregion
        }
    }
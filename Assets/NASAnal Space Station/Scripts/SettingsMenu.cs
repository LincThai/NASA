namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class SettingsMenu : MonoBehaviour
    {
        #region Fields

        // reference to audio mixer
        public AudioMixer audioMixer;

        // reference to dropdown menu
        public TMP_Dropdown resolutionDropdown;

        // array of resolutions for the platform
        Resolution[] resolutions;

        // variables to store settings values
        // other settings
        int setResIndex;
        int setQualityIndex;
        bool setFullscreen;

        // volume settings
        float setVolume;
        float setBGMvol;
        float setSFXvol;

        // int for fullscreen
        int fullscreenStat;

        #endregion

        #region Unity Methods

        void Start()
        {
            // Call function to setup arrays/lists
            SetupResArrayList();

            // set values
            PlayerPrefs.GetInt("ResIndex", setResIndex);
            PlayerPrefs.GetInt("Quality", setQualityIndex);
            PlayerPrefs.GetFloat("volume", setVolume);
            PlayerPrefs.GetFloat("BGMvolume", setBGMvol);
            PlayerPrefs.GetFloat("SFXvolume", setSFXvol);
            PlayerPrefs.GetInt("FullscreenStat", fullscreenStat);

            // revert to bool using intTobool function
            setFullscreen = intTobool(fullscreenStat);


        }
            #endregion

            #region Methods

        public void SetupResArrayList()
        {
            // collect resolution option in list/array
            resolutions = Screen.resolutions;

            // clear old/default options
            resolutionDropdown.ClearOptions();

            // create list of strings which are our options
            List<string> options = new List<string>();

            // variable that holds the index of current resolution
            int currentResolutionIndex = 0;

            // loop through each element is our resolutions array
            for (int i = 0; i < resolutions.Length; i++)
            {
                // for each element create a nicely formatted string
                string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
                // then add to list
                options.Add(option);

                // looks for the current resolution of screen/window
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    // sets current resolution idex for display
                    currentResolutionIndex = i;
                }
            }

            // add to dropdown menu
            resolutionDropdown.AddOptions(options);

            // shows the value
            resolutionDropdown.value = currentResolutionIndex;

            // refreshes the value displayes
            resolutionDropdown.RefreshShownValue();
        }

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

        public void SetFullscreen(bool isFullscreen)
        {
            // turns on or off fullscreen
            Screen.fullScreen = isFullscreen;

            // save value in player prefs as an int using boolToint function
            PlayerPrefs.SetInt("fullscreenStat", boolToint(isFullscreen));
        }

        public void ReturnToPriorScene()
        {
            // Loads MainMenu Scene
            SceneManager.LoadScene("MainMenu");
        }

        int boolToint(bool val)
        {
            if (val)
            {
                return 1;
            }
            else
            {
                return 0;
            }
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
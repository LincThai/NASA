namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;
    using TMPro;

    public class SettingsMenu : MonoBehaviour
    {
        // reerence to audio mixer
        public AudioMixer audioMixer;

        // reference to dropdown menu
        public TMP_Dropdown resolutionDropdown;

        // array of resolutions for the platform
        Resolution[] resolutions;

        void Start()
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
                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
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
        }         

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

        public void SetFullscreen(bool isFullscreen)
        {
            // turns on or off fullscreen
            Screen.fullScreen = isFullscreen;
        }
    }
}
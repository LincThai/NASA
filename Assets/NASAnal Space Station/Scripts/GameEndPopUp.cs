namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class GameEndPopUp : MonoBehaviour
    {
        #region Fields

        [Header("Text")]
        // reference to gameEndText
        public TMP_Text gameEndText;

        [Header("Panels")]
        // reference to lose and win panel
        public GameObject losePanel;
        public GameObject winPanel;

        // variables for game end
        int numSystemsRepaired;
        float remainingTime;
        int numberOfSystems;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // unlocks the cursor to allow player access to buttons
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            // access values saved in player prefs under the following names
            // and assign them to thr following variables
            remainingTime = PlayerPrefs.GetFloat("remainingTime");
            numSystemsRepaired = PlayerPrefs.GetInt("numSystemsRepaired");
            numberOfSystems = PlayerPrefs.GetInt("numberOfSystems");

            // Turn off win and lose panel
            losePanel.SetActive(false);
            winPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            // call ChangeEndText
            ChangeEndText();
        }

        #endregion

        #region Methods

        public void ChangeEndText()
        {
            // checks if the player has repaired all systems
            if (numSystemsRepaired == numberOfSystems)
            {
                // the player wins
                winPanel.SetActive(true);
                gameEndText.text = "You Win: You have " + remainingTime + " remaining";
            }
            // checks if the player ran out of time and if they haven't repaired all systems
            else if (remainingTime <= 0 && numSystemsRepaired < numberOfSystems)
            {
                // the player loses
                losePanel.SetActive(true);
                gameEndText.text = "You Lose: You ran out of time and didn't repair all systems ";
            }
        }

        public void Quit()
        {
            // close game
            Application.Quit();
        }

        public void ReturnMainMenu()
        {
            // load main menu / title screen
            SceneManager.LoadScene("MainMenu");
        }

        #endregion

    }
}
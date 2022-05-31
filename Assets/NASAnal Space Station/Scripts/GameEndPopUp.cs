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

        // reference to level manager
        LevelManager levelManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;

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
            ChangeEndText();
        }

        #endregion

        #region Methods

        public void ChangeEndText()
        {
            if (numSystemsRepaired == numberOfSystems)
            {
                winPanel.SetActive(true);
                gameEndText.text = "You Win";
            }

            else if (remainingTime <= 0 && numSystemsRepaired < numberOfSystems)
            {
                losePanel.SetActive(true);
                gameEndText.text = "You Lose";
            }
        }

        public void Quit()
        {
            // close game
            Application.Quit();
        }

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        #endregion

    }
}
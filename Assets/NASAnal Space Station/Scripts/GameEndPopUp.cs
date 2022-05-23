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

        // reference to game manager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // reference to GameManager Script
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
            if (gameManager.playerController.repairedSystems == gameManager.playerController.systemsToRepair)
            {
                gameEndText.text = "You Win";
            }

            else if (gameManager.timer.currentTime <= 0)
            {
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
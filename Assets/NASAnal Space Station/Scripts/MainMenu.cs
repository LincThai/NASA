namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        #region Fields

        // variable to reference GameManager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        public void Start()
        {
            // get refernece to game manager script
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

            // Set GaneState to preGame
            gameManager.gameState = GameState.preGame;
        }

        #endregion

        #region Methods

        public void PlayGame()
        {
            // load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // set GameState to game
            gameManager.gameState = GameState.game;
        }

        public void QuitGame()
        {
            // close application
            Application.Quit();
            Debug.Log("Quit");
        }

        #endregion
    }
}
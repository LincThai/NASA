namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PauseMenu : MonoBehaviour
    {
        #region Fields

        // bool to show whether game is paused or not
        public bool GameIsPaused = false;

        // reference to pause menu game object
        public GameObject pauseMenuUI;

        // reference to game manager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // get reference to game manager script
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        void Update()
        {
            //checks for the escape to be pressed down 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // checks if GameIsPaused is true
                if (GameIsPaused)
                {
                    // call Resume function 
                    Resume();
                }
                else
                {
                    // call Pause Function
                    Pause();
                }
            }
        }

        #endregion

        #region Methods

        public void Resume()
        {
            // turn off pause menu UI
            pauseMenuUI.SetActive(false);
            // set time scale to 1 to resume normal time speed
            Time.timeScale = 1f;
            // Set bool to false
            GameIsPaused = false;
            // return game state to game.
            gameManager.gameState = GameState.game;
        }

        public void Pause()
        {
            // turn on pause menu UI
            pauseMenuUI.SetActive(true);
            // set time scale to 0 to stop time from moving
            Time.timeScale = 0f;
            // set bool to true
            GameIsPaused = true;
            // set game state to paused
            gameManager.gameState = GameState.pause;
        }

        public void LoadMenu()
        {
            // set time scale to 1 to resume normal time speed
            Time.timeScale = 1f;
            // load main menu scene
            SceneManager.LoadScene("MainMenu");
        }

        #endregion

    }
}
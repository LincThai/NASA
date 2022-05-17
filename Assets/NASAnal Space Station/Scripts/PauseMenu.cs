namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PauseMenu : MonoBehaviour
    {
        #region Fields

        public static bool GameIsPaused = false;

        public GameObject pauseMenuUI;

        public GameManager gameManager;

        #endregion


        // Start is called before the first frame update
        void Start()
        {
              gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            gameManager.gameState = GameState.game;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            gameManager.gameState = GameState.pause;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            gameManager.gameState = GameState.preGame;
        }

    }
}
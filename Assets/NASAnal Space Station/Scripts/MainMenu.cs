namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        #region Methods

        public void PlayGame()
        {
            // load next scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("MainLevel_01");
            // set GameState to game
            //gameManager.gameState = GameState.game;
        }

        public void LoadSettings()
        {
            // load SettingsMenu scene
            SceneManager.LoadScene("SettingsMenu");
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
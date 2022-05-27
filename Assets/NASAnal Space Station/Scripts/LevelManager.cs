namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LevelManager : MonoBehaviour
    {
        #region Fields

        // set variables
        public int toolKitLimit;
        public int numberOfSystems;

        // variables for game end
        public int numSystemsRepaired;
        public float remainingTime;

        // variable to reference game manager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        void Start()
        {
            // get reference to game manager script
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        void Update()
        {
            // get data variables
            remainingTime = gameManager.timer.currentTime;
            numSystemsRepaired = gameManager.playerController.repairedSystems;

            // ensure this game object is not destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}
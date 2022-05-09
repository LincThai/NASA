namespace NASAnalSpaceStation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        #region Fields

        // Set Variables
        public GameState gameState;
        public PlayerState playerState;

        // Set Text Reference Variables
        public TMP_Text timerText;
        public TMP_Text toolKitText;

        // reference to player controller
        PlayerController playerController;

        // reference to timer
        GameTimer timer;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // set gamestate and playerstate
            gameState = GameState.preGame;
            playerState = PlayerState.gravity;

            // get reference to player controller script
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            // refeence timer script
            timer = GetComponent<GameTimer>();
        }

        // Update is called once per frame
        void Update()
        {
            // checks for imput and chnages player state
            if(Input.GetKeyDown(KeyCode.G))
            {
                // set player state to zero gravity
                playerState = PlayerState.zeroGravity;
            }

            // display text for number of toolkits
            toolKitText.text = playerController.noToolKits.ToString();

            // set Timespan Variable ts and use FromSeconds Function on currentTime Variable
            TimeSpan ts = TimeSpan.FromSeconds(timer.currentTime);

            // write to timerText a string formatted with Munutes and Seconds
            timerText.text = String.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);

        }

        #endregion
    }
    public enum GameState { preGame, game, dead, Pause }
    public enum PlayerState { gravity , zeroGravity }
}
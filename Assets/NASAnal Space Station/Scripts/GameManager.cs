namespace NASAnalSpaceStation
{
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
        }

        // Update is called once per frame
        void Update()
        {
            //
            if(Input.GetKeyDown(KeyCode.G))
            {
                // set player state to zero gravity
                playerState = PlayerState.zeroGravity;
            }

            toolKitText.text = playerController.noToolKits.ToString();
        }

        #endregion
    }
    public enum GameState { preGame, game, dead, Pause }
    public enum PlayerState { gravity , zeroGravity }
}
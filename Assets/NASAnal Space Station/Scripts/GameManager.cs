namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        #region Fields

        // Set Variables
        public GameState gameState;
        public PlayerState playerState;

        // reference to player controller
        public PlayerController playerController;

        // reference to timer
        public GameTimer timer;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // set playerstate
            playerState = PlayerState.gravity;

            // get reference to player controller script
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            // refeence timer script
            timer = GetComponent<GameTimer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (gameState == GameState.game)
            {
                // checks for imput and changes player state
                if (Input.GetKeyDown(KeyCode.G))
                {
                    // set player state to zero gravity
                    playerState = PlayerState.zeroGravity;
                }

                // checks for the 
                if (Input.GetKey(KeyCode.Escape))
                {
                    gameState = GameState.pause;
                }
            }
        }

        #endregion
    }
    public enum GameState { preGame, game, dead, pause }
    public enum PlayerState { gravity , zeroGravity }
}
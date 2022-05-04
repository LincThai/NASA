namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        #region Fields

        // Set Variables
        public GameState gameState;
        public PlayerState playerState;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            gameState = GameState.preGame;
            playerState = PlayerState.gravity;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                playerState = PlayerState.zeroGravity;
            }
        }

        #endregion
    }
    public enum GameState { preGame, game, dead, Pause }
    public enum PlayerState { gravity , zeroGravity }
}
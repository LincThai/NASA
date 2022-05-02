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

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            gameState = GameState.preGame;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    public enum GameState { preGame, game, dead, Pause }
    public enum PlayerState { gravity , zeroGravity }
}
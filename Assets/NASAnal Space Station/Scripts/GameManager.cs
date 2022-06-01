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
        public GameObject player;

        // reference to timer
        public GameTimer timer;

        public LevelManager levelManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // call setupManager Function
            setupManager();
        }

        public void setupManager()
        {
            // set playerstate and gamestate
            playerState = PlayerState.gravity;
            gameState = GameState.game;

            // get reference to player controller script
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            // get reference timer script
            timer = gameObject.GetComponent<GameTimer>();

            // get reference to LevelManager script
            levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        }

        // Update is called once per frame
        void Update()
        {
            // check if the gamestate is game
            if (gameState == GameState.game)
            {
                // checks for imput and changes player state
                if (Input.GetKeyDown(KeyCode.G))
                {
                    // set player state to zero gravity
                    playerState = PlayerState.zeroGravity;
                }

                // checks if currenttime is = 0
                if (timer.currentTime <= 0f)
                {
                    // change gamestate to dead
                    gameState = GameState.dead;
                }
                // checks if player has repaired all systems
                else if (playerController.repairedSystems == playerController.systemsToRepair)
                {
                    // change gamestate to dead
                    gameState = GameState.dead;
                }
            }

            // checks gamestate
            if (gameState == GameState.dead)
            {
                // save values
                PlayerPrefs.SetFloat("remainingTime", timer.currentTime);
                PlayerPrefs.SetInt("numSystemsRepaired", playerController.repairedSystems);
                PlayerPrefs.SetInt("numberOfSystems", levelManager.numberOfSystems);

                // load scene
                SceneManager.LoadScene("GameEnd");
            }
        }

        #endregion
    }
    public enum GameState { preGame, game, dead, pause }
    public enum PlayerState { gravity , zeroGravity }
}
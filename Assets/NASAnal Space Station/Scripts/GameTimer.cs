namespace NASAnalSpaceStation 
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameTimer : MonoBehaviour
    {
        #region fields

        // set variables
        // variable of current time
        public float currentTime;

        // variable of the time limit for a level
        public float levelTimeLimit;

        // reference game Manager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        private void Start()
        {
            // resets time for every level
            currentTime = levelTimeLimit;
  
            // check if game state is game
            gameManager = GetComponent<GameManager>();
            
            // Start Timer Coroutine
            StartCoroutine(Timer());


        }

        private void Update()
        {
            // checks if we are paused or not
            if (gameManager.gameState == GameState.game)
            {
                // calls PlaySoundOverTime function
                PlaySoundOverTime();
            }
            else
            {
                // check if a sound is being played
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_02"))
                {
                    // Stops playing the sound
                    FindObjectOfType<AudioManager>().Stop("Alarm_02");
                }
                // check if a sound is being played
                else if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_01"))
                {
                    // Stops playing the sound
                    FindObjectOfType<AudioManager>().Stop("Alarm_01");
                }
            }
        }


        #endregion

        #region Methods

        public IEnumerator Timer()
        {
            // while currentTime is greater than 0 complete the following
            while (currentTime > 0)
            {
                // deduct Time.deltaTime from current time
                currentTime -= Time.deltaTime;
                yield return null;
            }
        }

        public void PlaySoundOverTime()
        {
            // check if the currentTime is greater than half the levelTimeLimit
            if (currentTime >= levelTimeLimit / 2 )
            {
                // checks if the sound IsPlaying if it is false
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_02") == false)
                {
                    // Play the sound
                    FindObjectOfType<AudioManager>().Play("Alarm_02");
                }
            }
            // then if the first if is false it checks if the currentTime is
            // less than half the levelTimeLimit but greater than 0
            else if (currentTime < levelTimeLimit / 2 && currentTime > 0)
            {
                // then checks whether the sound isPlaying is true
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_02") == true)
                {
                    // stop playing the sound
                    FindObjectOfType<AudioManager>().Stop("Alarm_02");
                }
                // checks if this sound IsPlaying is false
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_01") == false)
                {
                    // plays the sound
                    FindObjectOfType<AudioManager>().Play("Alarm_01");
                }

            }
            // checks if current time is equal to or less than 0
            else if (currentTime <= 0)
            {
                // then checks whether the sound isPlaying is true
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_01") == true)
                {
                    // stop playing the sound
                    FindObjectOfType<AudioManager>().Stop("Alarm_01");
                }
            }
        }

        #endregion
    }
}
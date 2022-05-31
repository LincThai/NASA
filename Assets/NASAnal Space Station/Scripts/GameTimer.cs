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
            PlaySoundOverTime();
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
            if (currentTime >= levelTimeLimit / 2 )
            {
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_02") == false)
                {
                    FindObjectOfType<AudioManager>().Play("Alarm_02");
                }

            }
            else if (currentTime < levelTimeLimit / 2 && currentTime > 0)
            {
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_02") == true)
                {
                    FindObjectOfType<AudioManager>().Stop("Alarm_02");
                }
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_01") == false)
                {
                    FindObjectOfType<AudioManager>().Play("Alarm_01");
                }

            }
            else if (currentTime <= 0)
            {
                if (FindObjectOfType<AudioManager>().IsPlaying("Alarm_01") == true)
                {
                    FindObjectOfType<AudioManager>().Stop("Alarm_01");
                }
            }
        }

        #endregion
    }
}
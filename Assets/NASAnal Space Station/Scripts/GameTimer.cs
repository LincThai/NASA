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

        #endregion

        #region Unity Methods

        private void Start()
        {
            // resets time for every level
            currentTime = levelTimeLimit;

            // Start Timer Coroutine
            StartCoroutine(Timer());
        }

        #endregion

        #region Methods

        public IEnumerator Timer()
        {
            // while currentTime is greater than 0 complete the following
            while(currentTime > 0)
            {
                // deduct Time.deltaTime from current time
                currentTime -= Time.deltaTime;
                yield return null;
            }
        }

        #endregion
    }
}
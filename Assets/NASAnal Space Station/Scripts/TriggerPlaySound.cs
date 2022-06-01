namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TriggerPlaySound : MonoBehaviour
    {
        #region Fields

        // set string array
        public string[] soundNames;

        #endregion

        #region Methods

        void OnTriggerStay(Collider other)
        {
            // while the tag of other is equal to Player complete the following
            while (other.tag == "Player")
            {
                // variable i is equal to a random value from 0 to 2
                int i = Random.Range(0, 2);

                // check if sound is already playing
                if (FindObjectOfType<AudioManager>().IsPlaying(soundNames[i]) == false)
                {
                    // play sound with the name in array through audiomanager
                    FindObjectOfType<AudioManager>().Play(soundNames[i]);
                }
            }
        }

        #endregion
    }
}
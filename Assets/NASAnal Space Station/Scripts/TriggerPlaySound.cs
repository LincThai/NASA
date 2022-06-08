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
            if (other.tag == "Player")
            {
                // variable i is equal to a random value from 0 to 2
                int i = Random.Range(0, 3);

                // check if sound is already playing

                if (FindObjectOfType<AudioManager>().IsPlaying(soundNames[0]) == false && FindObjectOfType<AudioManager>().IsPlaying(soundNames[1]) == false && FindObjectOfType<AudioManager>().IsPlaying(soundNames[2]) == false)
                {
                    FindObjectOfType<AudioManager>().RandomPitch(0.9f, 1.1f, soundNames[i]);
                    FindObjectOfType<AudioManager>().Play(soundNames[i]);
                }

            }
        }

        #endregion
    }
}
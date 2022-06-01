namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class PopUpTrigger : MonoBehaviour
    {
        #region Fields

        // reference to bubble UI game object
        public GameObject textBubble;

        // text to write
        public string popUpText;

        // text to display
        public TMP_Text textDisplay;

        #endregion

        #region Methods

        public void OnTriggerEnter(Collider other)
        {
            // checks if the object that enters is the player
            if (other.tag == "Player")
            {
                // Turn on help text
                textBubble.SetActive(true);

                // change text
                textDisplay.text = popUpText;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            // checks if the object that exits is the player
            if (other.tag == "Player")
            {
                // Turn off help text
                textBubble.SetActive(false);
            }
        }

        #endregion
    }
}
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
        [TextArea(5, 10)]
        public string popUpText;

        // text to display
        public TMP_Text textDisplay;

        // bool to check if it is to be destroye
        public bool isNotPermanant;

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

                // if this trigger needs to be destroyed after use or not
                if (isNotPermanant)
                {
                    // destroys this game object
                    Destroy(gameObject);
                }
            }
        }

        #endregion
    }
}
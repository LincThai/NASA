namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PopUpTrigger : MonoBehaviour
    {
        #region Fields

        // reference to help text
        public GameObject helpText;

        #endregion

        #region Methods

        public void OnTriggerEnter(Collider other)
        {
            // checks if the object that enters is the player
            if (other.tag == "Player")
            {
                // Turn on help text
                helpText.SetActive(true);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            // checks if the object that exits is the player
            if (other.tag == "Player")
            {
                // Turn off help text
                helpText.SetActive(false);
            }
        }

        #endregion
    }
}
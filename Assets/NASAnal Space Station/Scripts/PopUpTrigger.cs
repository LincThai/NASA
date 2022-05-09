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
            helpText.SetActive(true);
        }

        public void OnTriggerExit(Collider other)
        {
            helpText.SetActive(false);
        }

        #endregion
    }
}
namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RepairTrigger : MonoBehaviour
    {
        #region Fields
        
        // set variables
        // reference to lights
        [Header("Lights")]
        public GameObject greenRepairedLight;
        public GameObject redBrokenLight;

        // reference to player controller
        PlayerController playerController;

        // set variable for cost requirements
        public int cost = 1;

        #endregion

        #region Methods

        private void OnTriggerStay(Collider other)
        {
            // checks if the object that enters is the player
            if (other.tag == "Player")
            {
                // reference plater controller script
                playerController = other.GetComponent<PlayerController>();

                // check for bfire button imput
                if (Input.GetButtonDown("Fire1"))
                {
                    // check for that the number of tookits is greater than cost
                    if (playerController.noToolKits >= cost)
                    {
                        // deduct cost from noToolKits
                        playerController.noToolKits -= cost;

                        // switch lights
                        redBrokenLight.SetActive(false);
                        greenRepairedLight.SetActive(true);

                        // increase the number of repaired systems by 1
                        playerController.repairedSystems += 1;

                        // turn off trigger game object.
                        gameObject.SetActive(false);
                    }   
                }
            }
        }

        #endregion
    }
}
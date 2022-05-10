namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RepairTrigger : MonoBehaviour
    {
        #region Fields
        
        // set variables
        // reference to repair prefab
        //public GameObject repairPrefab;

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
                    }   
                }
            }
        }

        #endregion
    }
}
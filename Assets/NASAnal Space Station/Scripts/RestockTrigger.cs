namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RestockTrigger : MonoBehaviour
    {
        #region Fields

        // set variables
        // variable to reference PlayerController
        PlayerController playerController;

        #endregion

        #region Methods
        
        public void OnTriggerStay(Collider other)
        {
            // checks if the object that enters is the player
            if (other.tag == "Player")
            {
                // reference plater controller script
                playerController = other.GetComponent<PlayerController>();
                
                // check for the fire input button
                if (Input.GetButtonDown("Fire1"))
                {
                    // play sound
                    FindObjectOfType<AudioManager>().Play("Restock");

                    // check if number of toolkits equals zero
                    if (playerController.noToolKits == 0)
                    {
                        // call resetInventory function from PlayerController
                        playerController.ResetInventory();
                    }
                    // check if the number of toolkits is greater than zero
                    else if (playerController.noToolKits > 0)
                    {
                        // create and int variable which holds the difference between
                        // the limit and the current number of toolkits
                        int restockAmmount = playerController.toolKitLimit - playerController.noToolKits;

                        // add restock ammount to the number of toolkits
                        playerController.noToolKits += restockAmmount;
                    }
                }
            }
        }

        #endregion
    }
}

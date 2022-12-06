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
        public GameObject fixedPanel;
        public GameObject brokenPanel;
        public GameObject spark;
        public GameObject sparkSounds; 


        // reference to player controller
        PlayerController playerController;

        // set variable for cost requirements
        public int cost = 1;

        // string name of sounds
        string nameOne = "Repaired_01";
        string nameTwo = "Repaired_02";

        #endregion

        #region Methods

        private void OnTriggerStay(Collider other)
        {
            // checks if the object that enters is the player
            if (other.tag == "Player")
            {
                // reference plater controller script
                playerController = other.GetComponent<PlayerController>();

                // randomise repaired sound
                int i = Random.Range(0, 2);

                // check for bfire button imput
                if (Input.GetButtonDown("Fire1"))
                {
                    //Debug.Log("Player pressed Left Mouse Button.");

                    // check for that the number of tookits is greater than cost
                    if (playerController.noToolKits >= cost)
                    {
                        // deduct cost from noToolKits
                        playerController.noToolKits -= cost;

                        // switch lights
                        redBrokenLight.SetActive(false);
                        greenRepairedLight.SetActive(true);
                        
                        Instantiate(fixedPanel, brokenPanel.transform.position, brokenPanel.transform.rotation);
                        Destroy(brokenPanel);
                        Destroy(spark);
                        Destroy(sparkSounds);

                        // increase the number of repaired systems by 1
                        playerController.repairedSystems += 1;

                        if (i == 0)
                        {
                            // play sound
                            FindObjectOfType<AudioManager>().Play(nameOne);
                        }
                        else if (i == 1)
                        {
                            // play sound
                            FindObjectOfType<AudioManager>().Play(nameTwo);
                        }

                        // turn off trigger game object.
                        gameObject.SetActive(false);
                    }   
                }
            }
        }

        #endregion
    }
}
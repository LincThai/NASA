namespace NASAnalSpaceStation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class HUDdisplay : MonoBehaviour
    {
        #region Fields
        // reference text
        public TMP_Text timerText;
        public TMP_Text toolKitText;

        GameManager gameManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            // display text for number of toolkits
            toolKitText.text = gameManager.playerController.noToolKits.ToString();

            // set Timespan Variable ts and use FromSeconds Function on currentTime Variable
            TimeSpan ts = TimeSpan.FromSeconds(gameManager.timer.currentTime);

            // write to timerText a string formatted with Munutes and Seconds
            timerText.text = String.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);
        }

        #endregion
    }
}
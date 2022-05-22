namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class GameEndPopUp : MonoBehaviour
    {
        #region Fields

        [Header("Text")]
        // reference to gameEndText
        public TMP_Text gameEndText;

        [Header("Panels")]
        // reference to lose and win panel
        public GameObject losePanel;
        public GameObject winPanel;

        // reference to game manager
        GameManager gameManager;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // reference to GameManager Script
            gameManager = GameObject.FindGameObjectWithTag("GameControllet").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        #endregion

        #region Methods

        public void ChangeEndText()
        {
            if ()
        }

        #endregion

    }
}
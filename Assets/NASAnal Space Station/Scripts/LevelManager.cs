namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LevelManager : MonoBehaviour
    {
        // set variables
        public int toolKitLimit;
        public int numberOfSystems;

        // variables for game end
        public int numSystemsRepaired;
        public int remainingTime;

        void Start()
        {
            
        }

        private void Update()
        {
            remainingTime = ;
            numberOfSystems = ;

            DontDestroyOnLoad(gameObject);
        }
    }
}
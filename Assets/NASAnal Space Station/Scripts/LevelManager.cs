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

        void Start()
        {
            
        }

        private void Update()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
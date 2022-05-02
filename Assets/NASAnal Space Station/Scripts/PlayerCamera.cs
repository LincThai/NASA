namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerCamera : MonoBehaviour
    {
        #region Fields

        // Set Variables
        public float mouseSensitivity = 100f;

        // reference to player
        public Transform playerBody;

        // rotation value
        float xRotation = 0f;

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            // Locks cursor to center of screen and hides
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            // Get Mouse Movement Input multiply by sensitivity and time
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // assign mouseY input to a variable for clamping
            xRotation -= mouseY;
            // clamp x rotation between 90 and -90 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate camera up or down based on its own transform
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // rotate the body with the camera for left and right rotation
            playerBody.Rotate(Vector3.up * mouseX);

            //if(playerState == )
            //{
            //playerBody.Rotate(Vector3.right * MouseY)
            //}
        }

        #endregion
    }
}

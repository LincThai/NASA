namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {

        #region Fields

        // set up movement variables
        [Header("Movement")]
        // set speed
        public float moveSpeed = 6f;

        // set drag variable
        public float rbDrag = 6f;

        [Header("Jump")]
        public float JumpForce = 5f;

        // set horizontal and vertical movement variables
        float horizontalMove;
        float verticalMove;

        // ground check
        bool isGrounded;

        // set up a vector 3 variable for movement direction
        Vector3 moveDirection;

        // variable to assign the riid body to
        Rigidbody rb;

        #endregion

        #region Unity Methods

        private void Start()
        {
            // assigns the rigid body to rb
            rb = GetComponent<Rigidbody>();
            
            // freeze rotation of player so does not topple over
            rb.freezeRotation = true;
        }

        private void Update()
        {

            isGrounded = Physics.Raycast(transform.position, Vector3.down, 2.5f);

            Debug.Log(isGrounded);

            // Call MyInput function
            MyInput();

            // call ControlDrag Function
            ControlDrag();
 
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                Jump();
                Debug.Log("jumped");
            }
        }

        private void FixedUpdate()
        {
            // call MovePlayer function
            MovePlayer();
        }

        #endregion

        #region Methods

        void MyInput()
        {
            // collect input data
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");

            // move in the direction relative to the direction of sight
            moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;
        }

        void Jump()
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }

        void ControlDrag()
        {
            rb.drag = rbDrag;
        }

        void MovePlayer()
        {
            // add a normalized force multiplied by the movement speed as an acceleration
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        }

        #endregion
    }
}
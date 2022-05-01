namespace NASAnalSpaceStation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
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

        private void Start()
        {
            // assigns the rigid body to rb
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        private void Update(){
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);
            Debug.Log(isGrounded);

            // Call MyInput function
            MyInput();

            // call ControlDrag Function
            ControlDrag();

            if (Input.GetKeyDown("Jump") && isGrounded)
            {
                Jump();
            }
        }

        void MyInput(){
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

        void ControlDrag(){
            rb.drag = rbDrag;
        }

        private void FixedUpdate(){
            // call MovePlayer function
            MovePlayer();
        }

        void MovePlayer(){
            // add a normalized force multiplied by the movement speed as an acceleration
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        }
    }
}
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

        [Header("Zero-Gravity")]
        // Gravity Check
        public bool hasGravity;

        // reference to gameManager
        GameManager gameManager;

        [Header("Crouch")]
        // reference to player's capsule collider
        CapsuleCollider playerCol;

        // original height
        float originHeight;
        // new height
        public float reducedHeight;

        [Header("Sprint")]
        // new speed when sprinting
        public float sprintSpeed = 24f;
        // original walk speed
        public float walkSpeed = 12f;
        // speed of acceleration/deceleration from walk to sprint and vice versa
        public float acceleration = 10f;

        [Header("Inventory")]
        // set variable for number of toolkits
        public int noToolKits;
        // variable to limit the number of toolkits in inventory per level
        public int toolKitLimit = 2;

        #endregion

        #region Unity Methods

        private void Start()
        {
            // assigns the rigid body to rb
            rb = GetComponent<Rigidbody>();
            
            // freeze rotation of player so does not topple over
            rb.freezeRotation = true;

            // Gravity always starts true
            hasGravity = true;

            // get reference the game manager script via the object tagged "GameController"
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

            // get a reference to capsule collider on player
            playerCol = GetComponent<CapsuleCollider>();

            // set origin height to the height of the capsule collider
            originHeight = playerCol.height;

            // call ResetInventory
            ResetInventory();
        }

        private void Update()
        {
            // call gravity switch function
            GravitySwitch();

            // check if the value of hasGravity bool is true or false
            if (hasGravity == false)
            {
                // switch rigidbody gravity off
                rb.useGravity = false;
            }
            else
            {
                // switch rigidbody gravity on
                rb.useGravity = true;
            }

            // check for input
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.forward * 1f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(Vector3.forward * -1f);
            }

            // check if C key is pressed down
            if (Input.GetKey(KeyCode.C))
            {
                // call crouch function
                Crouch();
            }
            // check if C key is let go
            else if (Input.GetKeyUp(KeyCode.C))
            {
                // Call stand Function
                Stand();
            }

            // send a physics raycast downward by 2.5m to check for ground to set the value of isGrounded
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 2.5f);

            // Call MyInput function
            MyInput();

            // call ControlDrag Function
            ControlDrag();

            // call ControlSpeed
            ControlSpeed();
            
            // Checks for jump button input
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                // call jump function
                Jump();
            }

            // call inventory
            Inventory();
        }

        private void FixedUpdate()
        {
            // call MovePlayer function
            MovePlayer();
        }

        #endregion

        #region Methods

        public void MyInput()
        {
            // collect input data
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");

            // move in the direction relative to the direction of sight
            moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;
        }

        public void Crouch()
        {
            // check if player has gravity
            if (hasGravity == false)
            {
                // and a downward force
                rb.AddForce(transform.up * -JumpForce, ForceMode.Impulse);
            }
            else
            {
                // Change collider height
                playerCol.height = reducedHeight;
            }
        }

        public void Stand()
        {
            playerCol.height = originHeight;
        }

        public void Jump()
        {
            // adds a one time upward force
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }

        public void ControlSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
            }
        }

        public void ControlDrag()
        {
            // changes the drag value on the rigid body
            rb.drag = rbDrag;
        }

        public void MovePlayer()
        {
            // add a normalized force multiplied by the movement speed as an acceleration
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        }

        public void GravitySwitch()
        {
            // check if playerState equals zeroGravity
            if (gameManager.playerState == PlayerState.zeroGravity)
            {
                //has gravity becomes false
                hasGravity = false;
                Debug.Log(false);
            }
            // Check if playerState equals gravity
            else if (gameManager.playerState == PlayerState.gravity)
            {
                // has gravity becomes true
                hasGravity = true;

            }
        }

        public void Inventory()
        {
            // checks whether the players inventory is grester than the limit for the level
            if (noToolKits > toolKitLimit)
            {
                // call reset inventory function
                ResetInventory();
            }
            // checks if the number of toolkits is below 0 
            else if (noToolKits < 0)
            {
                // return the number of toolkits to zero
                noToolKits = 0;
            }
        }

        public void ResetInventory()
        {
            // sets the number of toolkits to the limit
            noToolKits = toolKitLimit;
        }

        #endregion
    }
}
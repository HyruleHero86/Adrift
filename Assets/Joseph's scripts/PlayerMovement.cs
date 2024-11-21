using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts

{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;

        public float currentSpeed;
        public float walkSpeed = 2.5f;
        public float speedMultiplier = 3f;

        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        Vector3 velocity;
        bool isGrounded;

        public bool isHiding = false; // Add this line
        public bool isIncapacitated = false;

        // Reference to the PlayerInputActions
        private PlayerInputActions inputActions;
        private Vector2 movementInput; // Stores the Move input
        private bool isSprinting;

        private void OnEnable()
        {
            // Initialize and enable the PlayerInputActions
            inputActions = new PlayerInputActions();
            inputActions.Player.Enable();

            // Subscribe to the Move action
            inputActions.Player.Move.performed += OnMovePerformed;
            inputActions.Player.Move.canceled += OnMoveCanceled;

            // Subscribe to Jump action
            inputActions.Player.Jump.performed += OnJumpPerformed;

            // Subscribe to Sprint action
            inputActions.Player.Sprint.performed += OnSprintPerformed;
            inputActions.Player.Sprint.canceled += OnSprintCanceled;
        }

        private void OnDisable()
        {
            // Unsubscribe from the Move action 
            inputActions.Player.Move.performed -= OnMovePerformed;
            inputActions.Player.Move.canceled -= OnMoveCanceled;

            // Unsubscribe from Jump action
            inputActions.Player.Jump.performed -= OnJumpPerformed;

            // Unsubscribe from Sprint action
            inputActions.Player.Sprint.performed -= OnSprintPerformed;
            inputActions.Player.Sprint.canceled -= OnSprintCanceled;

            // Disable input actions
            inputActions.Player.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            if (isHiding || isIncapacitated) return;  // Prevent actions if hiding or incapacitated

            // Grounded Control
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // Initial Velocity Control
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Adjust speed
            if (isSprinting)
            {
                currentSpeed = walkSpeed * speedMultiplier; // Increase speed when sprinting
            }
            else
            {
                currentSpeed = walkSpeed; // Default to walking speed
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * currentSpeed * Time.deltaTime);

            // Gravity control 
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            // Read the input value (Vector2) when movement occurs
            movementInput = context.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            // Reset the movement input when the movement is canceled
            movementInput = Vector2.zero;
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        private void OnSprintPerformed(InputAction.CallbackContext context)
        {
            isSprinting = true;
        }

        private void OnSprintCanceled(InputAction.CallbackContext context)
        {
            isSprinting = false;
        }

        public bool IsPlayerHiding()
        {
            return isHiding;
        }

        public void SetIncapacitated(bool isIncapacitated)
        {
            this.isIncapacitated = isIncapacitated;

            // Disable MouseLook and pause the animation when incapacitated
            MouseLook mouseLook = GetComponentInChildren<MouseLook>();
            if (mouseLook != null)
            {
                if (isIncapacitated)
                    mouseLook.DisableMouseLook(); // Disable camera movement
                else
                    mouseLook.EnableMouseLook();  // Re-enable camera movement
            }

            Animator animator = GetComponentInChildren<Animator>();
            if (animator != null)
            {
                if (isIncapacitated)
                {
                    animator.SetTrigger("Downed"); // Trigger the downed animation
                }
            }

            if (controller != null)
            {
                controller.enabled = !isIncapacitated;
            }
        }

        public bool IsIncapacitated()
        {
            return isIncapacitated;
        }

        public void RevivePlayer()
        {
            if (isIncapacitated)
            {
                isIncapacitated = false;

                // Trigger the revive animation
                ChangeAnimation playerAnimation = GetComponent<ChangeAnimation>();
                if (playerAnimation != null)
                {
                    playerAnimation.PlayReviveAnimation();
                }

                // Enable MouseLook and resume animation when revived
                MouseLook mouseLook = GetComponentInChildren<MouseLook>();
                if (mouseLook != null)
                {
                    mouseLook.EnableMouseLook();
                }

                Animator animator = GetComponentInChildren<Animator>();
                if (animator != null)
                {
                    animator.speed = 1f;
                }

                if (controller != null)
                {
                    controller.enabled = true;
                }
            }
        }

    }
}
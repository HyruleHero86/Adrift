using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Update is called once per frame
        void Update()
        {
            // Grounded Control
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // Initial Velocity Control
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Check for sprinting
            bool isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);

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

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}

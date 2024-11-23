﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    public bool isIncapacitated = false;

    public AudioClip footStepSound;
     public float footStepDelay;
 
     private float nextFootstep = 0;

    // Update is called once per frame
    void Update()
    {
        if (isIncapacitated) return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
            {
            velocity.y = -2f;
            }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && isGrounded)
         {
             nextFootstep -= Time.deltaTime;
             if (nextFootstep <= 0) 
             {
              GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
              nextFootstep += footStepDelay;
             }
         }
    }

    public void SetIncapacitated(bool isIncapacitated)
    {
        this.isIncapacitated = isIncapacitated;

        Animator animator = GetComponentInChildren<Animator>();
        if (isIncapacitated)
        {
            animator.SetTrigger("Downed"); // Trigger the downed animation
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

            if (controller != null)
            {
                controller.enabled = true;
            }
        }
    }
}



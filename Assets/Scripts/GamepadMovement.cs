using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float lookSpeed = 300f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public CharacterController characterController;

    private GamepadInputActions inputActions;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isSprinting = false;
    private bool jump = false;
    private bool interact = false;
    private bool dropLeft = false;
    private bool dropRight = false;
    
    private Vector3 velocity;

    void Awake()
    {
        inputActions = new GamepadInputActions();
        characterController = GetComponent<CharacterController>();

        // Set up input action callbacks
        inputActions.Gamepad.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gamepad.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Gamepad.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Gamepad.Look.canceled += ctx => lookInput = Vector2.zero;

        inputActions.Gamepad.Jump.performed += ctx => jump = ctx.ReadValueAsButton();
        inputActions.Gamepad.Jump.canceled += ctx => jump = false;

        inputActions.Gamepad.Sprint.performed += ctx => isSprinting = ctx.ReadValueAsButton();
        inputActions.Gamepad.Sprint.canceled += ctx => isSprinting = false;

        inputActions.Gamepad.Interaction.performed += ctx => interact = ctx.ReadValueAsButton();
        inputActions.Gamepad.Interaction.canceled += ctx => interact = false;

        inputActions.Gamepad.DropL.performed += ctx => dropLeft = ctx.ReadValueAsButton();
        inputActions.Gamepad.DropL.canceled += ctx => dropLeft = false;

        inputActions.Gamepad.DropR.performed += ctx => dropRight = ctx.ReadValueAsButton();
        inputActions.Gamepad.DropR.canceled += ctx => dropRight = false;
    }

    void OnEnable()
    {
        inputActions.Gamepad.Enable();
    }

    void OnDisable()
    {
        inputActions.Gamepad.Disable();
    }

    void Update()
    {
        Move();
        Look();
        HandleJump();
        HandleInteract();
        HandleDropLeft();
        HandleDropRight();
    }

    void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);

        if (characterController.isGrounded)
        {
            velocity.y = -2f; // Small value to keep the player grounded

            if (jump)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        Vector2 look = lookInput * lookSpeed * Time.deltaTime;
        transform.Rotate(0, look.x, 0);
    }

    void HandleJump()
    {
        // Jump logic is already integrated in Move method
    }

    void HandleInteract()
    {
        if (interact)
        {
            // Interact logic here
            Debug.Log("Interact");
        }
    }

    void HandleDropLeft()
    {
        if (dropLeft)
        {
            // Drop left logic here
            Debug.Log("Drop Left");
        }
    }

    void HandleDropRight()
    {
        if (dropRight)
        {
            // Drop right logic here
            Debug.Log("Drop Right");
        }
    }
}


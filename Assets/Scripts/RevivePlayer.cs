using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevivePlayer : MonoBehaviour
{
    public float reviveDistance = 2f; // Maximum distance for reviving
    private PlayerInputActions inputActions;

    private void OnEnable()
    {
        // Initialize and enable the PlayerInputActions
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();

        // Subscribe to the Revive action
        inputActions.Player.Revive.performed += OnRevivePerformed;
    }

    private void OnDisable()
    {
        // Unsubscribe from the Revive action
        inputActions.Player.Revive.performed -= OnRevivePerformed;

        // Disable input actions
        inputActions.Player.Disable();
    }

    private void OnRevivePerformed(InputAction.CallbackContext context)
    {
        AttemptRevive();
    }

    private void AttemptRevive()
    {
        // Find all players tagged "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            if (player != gameObject) // Skip self
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

                if (playerMovement != null && playerMovement.IsIncapacitated())
                {
                    // Check if the player is within revive distance
                    float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                    if (distanceToPlayer <= reviveDistance)
                    {
                        // Trigger reviving animation
                        ChangeAnimation myAnimation = GetComponent<ChangeAnimation>();
                        if (myAnimation != null)
                        {
                            myAnimation.PlayRevivingAnimation();
                        }

                        // Revive the incapacitated player
                        playerMovement.RevivePlayer();
                        break; // Exit after first successful revive
                    }
                }
            }
        }
    }
}
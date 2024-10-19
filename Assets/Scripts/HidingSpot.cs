using TMPro;
using UnityEngine;
public class HidingSpot : MonoBehaviour
{
    private bool playerInRange = false;
    private bool isHiding = false;
    private GameObject player;
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private MouseLook mouseLook;
    private Renderer playerRenderer;
    public GameObject hidePromptUI;  // Reference to the UI TextMeshPro GameObject

    private void Start()
    {
        // Make sure the UI prompt is hidden at the start
        if (hidePromptUI != null)
        {
            hidePromptUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;

            playerMovement = player.GetComponent<PlayerMovement>();
            mouseLook = player.GetComponentInChildren<MouseLook>();
            characterController = player.GetComponent<CharacterController>();

            playerRenderer = player.transform.Find("Futuristic_Soldier").GetComponent<Renderer>();

            // Show the UI prompt
            if (hidePromptUI != null)
            {
                hidePromptUI.SetActive(true);
                hidePromptUI.GetComponent<TextMeshProUGUI>().text = "Press 'E' to Hide";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;

            // Hide the UI prompt
            if (hidePromptUI != null)
            {
                hidePromptUI.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleHide();
        }
    }

    private void ToggleHide()
    {
        if (player != null && playerRenderer != null)
        {
            if (!isHiding)
            {
                playerRenderer.enabled = false;
                DisablePlayerMovement();

                isHiding = true;

                // Update UI prompt to "Press 'E' to Exit"
                if (hidePromptUI != null)
                {
                    hidePromptUI.GetComponent<TextMeshProUGUI>().text = "Press 'E' to Exit";
                }
            }
            else
            {
                playerRenderer.enabled = true;
                EnablePlayerMovement();

                isHiding = false;

                // Update UI prompt to "Press 'E' to Hide"
                if (hidePromptUI != null)
                {
                    hidePromptUI.GetComponent<TextMeshProUGUI>().text = "Press 'E' to Hide";
                }
            }
        }
    }

    private void DisablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (mouseLook != null)
        {
            mouseLook.enabled = false;
        }

        if (characterController != null)
        {
            characterController.enabled = false;
        }
    }

    private void EnablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        if (mouseLook != null)
        {
            mouseLook.enabled = true;
        }

        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }
}
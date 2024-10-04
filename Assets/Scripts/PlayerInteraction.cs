using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI promptText; // Use TextMeshProUGUI
    private IInteractable currentInteractable;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.Highlight(false);
                    }
                    currentInteractable = interactable;
                    currentInteractable.Highlight(true);
                }

                promptText.gameObject.SetActive(true);
                promptText.text = "Press E to interact"; // Set the prompt text
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    if (interactable is Barrel barrel)
                    {
                        barrel.SetPlayerTransform(transform);
                    }
                }
            }
            else
            {
                if (currentInteractable != null)
                {
                    currentInteractable.Highlight(false);
                    currentInteractable = null;
                }
                promptText.gameObject.SetActive(false);
            }
        }
        else
        {
            if (currentInteractable != null)
            {
                currentInteractable.Highlight(false);
                currentInteractable = null;
            }
            promptText.gameObject.SetActive(false);
        }
    }
}
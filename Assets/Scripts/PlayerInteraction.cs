using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI promptText;
    private IInteractable currentInteractable;
    public Transform holdPointRight; // Right hand hold point
    public Transform holdPointLeft; // Left hand hold point
    private PickableItem heldItemRight;
    private PickableItem heldItemLeft;
    public float dropInteractionDelay = 0.5f; // Half a second delay

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check for an interactable object in front of the player
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Highlight the new interactable and show the prompt
                if (currentInteractable != interactable)
                {
                    currentInteractable?.Highlight(false);
                    currentInteractable = interactable;
                    currentInteractable.Highlight(true);
                }

                promptText.gameObject.SetActive(true);
                promptText.text = "Press E to interact";

                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("Interact button pressed");
                    interactable.Interact();
                    if (interactable is PickableItem pickableItem)
                    {
                        TryPickUpItem(pickableItem);
                    }
                }
            }
            else
            {
                // Hide the prompt and un-highlight the interactable
                promptText.gameObject.SetActive(false);
                currentInteractable?.Highlight(false);
                currentInteractable = null;
            }
        }
        else
        {
            // Hide the prompt and un-highlight the interactable
            promptText.gameObject.SetActive(false);
            currentInteractable?.Highlight(false);
            currentInteractable = null;
        }

        // Check for drop input
        if (Input.GetButtonDown("Right-Drop"))
        {
            DropRightItem();
        }

        if (Input.GetButtonDown("Left-Drop"))
        {
            DropLeftItem();
        }
    }

    private void TryPickUpItem(PickableItem item)
    {
        if (item == null)
        {
            Debug.LogError("PickableItem is null in PickUpItem!");
            return;
        }

        Debug.Log($"Trying to pick up item: {item.name}");

        // Check which hand to use
        if (heldItemRight == null && holdPointRight != null)
        {
            HoldItemInHand(item, holdPointRight, ref heldItemRight);
        }
        else if (heldItemLeft == null && holdPointLeft != null)
        {
            HoldItemInHand(item, holdPointLeft, ref heldItemLeft);
        }
        else
        {
            Debug.Log("Both hands are full. Cannot pick up item.");
        }
    }

    private void HoldItemInHand(PickableItem item, Transform holdPoint, ref PickableItem heldItem)
    {
        Debug.Log($"Holding item in hand: {item.name}");

        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        if (itemRigidbody == null)
        {
            Debug.LogError("Rigidbody is missing on " + item.name + " in PickUpItem!");
            return;
        }

        heldItem = item;
        item.gameObject.SetActive(true);
        item.transform.SetParent(holdPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.Rotate(0f, 0f, 180f);

        item.GetComponent<Rigidbody>().isKinematic = true;
        itemRigidbody.isKinematic = true;
    }

    private void DropRightItem()
    {
        if (heldItemRight != null)
        {
            Debug.Log($"Dropping item from right hand: {heldItemRight.name}");
            StartCoroutine(DropHeldItem(heldItemRight));
            heldItemRight = null;
        }
    }

    private void DropLeftItem()
    {
        if (heldItemLeft != null)
        {
            Debug.Log($"Dropping item from left hand: {heldItemLeft.name}");
            StartCoroutine(DropHeldItem(heldItemLeft));
            heldItemLeft = null;
        }
    }

    private IEnumerator DropHeldItem(PickableItem heldItem)
    {
        heldItem.transform.SetParent(null);
        Rigidbody itemRigidbody = heldItem.GetComponent<Rigidbody>();
        if (itemRigidbody == null)
        {
            Debug.LogError("Rigidbody is missing on " + heldItem.name + " in DropItem!");
            yield break;
        }
        itemRigidbody.isKinematic = false;

        Vector3 dropPosition = transform.position + transform.forward * 2 + Vector3.up * 1;
        heldItem.transform.position = dropPosition;

        heldItem.gameObject.SetActive(true);

        // Prevent immediate re-interaction
        heldItem.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        yield return new WaitForSeconds(dropInteractionDelay);

        // Reset the item's layer back to the interactable layer
        heldItem.gameObject.layer = LayerMask.NameToLayer("Interactable");

        // Ensure proper highlight reset
        if (heldItem.GetComponent<IInteractable>() != null)
        {
            heldItem.GetComponent<IInteractable>().Highlight(false);
        }
    }
}

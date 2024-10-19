using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI promptText; 
    private IInteractable currentInteractable;
    public Transform holdPoint;
    private PickableItem heldItem;

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
                    currentInteractable?.Highlight(false);
                    currentInteractable = interactable;
                    currentInteractable.Highlight(true);
                }

                promptText.gameObject.SetActive(true);
                promptText.text = "Press E to interact";

         

                if (Input.GetButtonDown("Interact")) // Ensure this matches your input key setup
                {
                    interactable.Interact();
                    if (interactable is PickableItem pickableItem)
                    {
                        PickUpItem(pickableItem);
                    }
                }

            }
            else
            {
                promptText.gameObject.SetActive(false);
                currentInteractable?.Highlight(false);
                currentInteractable = null;
            }
        }
        else
        {
            promptText.gameObject.SetActive(false);
            currentInteractable?.Highlight(false);
            currentInteractable = null;
        }
        if (Input.GetButtonDown("Drop"))
        {
            DropItem();
        }
    }

    //PickUp Item function
    private void PickUpItem(PickableItem item)
    {
        if (item == null)
        {
            Debug.LogError("PickableItem is null in PickUpItem!");
            return;
        }
        if (holdPoint == null)
        {
            Debug.LogError("HoldPoint is not assigned in PickUpItem!");
            return;
        }
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        if (itemRigidbody == null)
        {
            Debug.LogError("Rigidbody is missing on " + item.name + " in PickUpItem!");
            return;
        }

        heldItem = item; //store held items
        item.gameObject.SetActive(true); //Reactivate item into hand
        item.transform.SetParent(holdPoint); 

        //position and rotation of item
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity; //resets rotation

        //Additional rotation to make sure item is in the correct position
        item.transform.Rotate(0f, 0f, 180f);

        item.GetComponent<Rigidbody>().isKinematic = true;
        itemRigidbody.isKinematic = true;
        Debug.Log(item.item.name + " is now in hand.");
    }

    //Drop Item Function
    private void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null);
            heldItem.GetComponent<Rigidbody>().isKinematic = false;

            // Calculate a new drop position slightly in front of the player
            Vector3 dropPosition = transform.position + transform.forward * 2 + Vector3.up * 1; // Adjust the multiplier as needed
            heldItem.transform.position = dropPosition;

            heldItem.gameObject.SetActive(true); // Ensure the item is active
            Debug.Log(heldItem.name + " dropped at " + dropPosition);

            heldItem = null;
            Debug.Log("Item dropped.");

          
        }
    }
}
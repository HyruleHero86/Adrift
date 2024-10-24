using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This barrel script will be deleted
public class Barrel : MonoBehaviour, IInteractable
{
    private bool isPickedUp = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private new Renderer renderer;
    private Material originalMaterial;
    public Material highlightMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void Interact()
    {
        if (!isPickedUp)
        {
            PickUp();
        }
        else
        {
            Drop();
        }
    }

    private void PickUp()
    {
        isPickedUp = true;
        rb.isKinematic = true; // Disable physics
        transform.SetParent(playerTransform); // Attach to player
        transform.localPosition = new Vector3(0, 1, 1); // Adjust position relative to player
        Debug.Log("Barrel picked up!");
    }

    private void Drop()
    {
        isPickedUp = false;
        rb.isKinematic = false; // Enable physics
        transform.SetParent(null); // Detach from player
        Debug.Log("Barrel dropped!");
    }

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }

    public void Highlight(bool highlight)
    {
        if (highlight)
        {
            renderer.material = highlightMaterial;
        }
        else
        {
            renderer.material = originalMaterial;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour, IInteractable
{
    private bool isBeingPushed = false;
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
        isBeingPushed = !isBeingPushed;
        Debug.Log("Cart interaction toggled. Is being pushed: " + isBeingPushed);
    }

    void FixedUpdate()
    {
        if (isBeingPushed)
        {
            // Apply force to the cart to push it forward
            rb.AddForce(transform.forward * 10f);
        }
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

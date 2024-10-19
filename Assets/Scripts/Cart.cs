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
        //constraint to prevent undesired movement
        rb.constraints= RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Interact()
    {
        isBeingPushed = !isBeingPushed;
        Debug.Log("Cart interaction toggled. Is being pushed: " + isBeingPushed);

        if (!isBeingPushed)
        {
            rb.velocity = Vector3.zero; //stops cart immediately
        }
    }

    void FixedUpdate()
    {
        if (isBeingPushed)
        {
            // Apply force to the cart to push it forward
            rb.AddForce(transform.forward * 2f);
        }
    }

    public void Highlight(bool highlight)
    {
       renderer.material = highlight ? highlightMaterial : originalMaterial;
    }
}

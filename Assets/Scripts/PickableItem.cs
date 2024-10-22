using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    private new Renderer renderer;
    private Material originalMaterial;
    public Material highlightMaterial;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void Interact()
    {
        Debug.Log("Item has been picked up!");
        Destroy(gameObject); // Remove the item from the scene
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

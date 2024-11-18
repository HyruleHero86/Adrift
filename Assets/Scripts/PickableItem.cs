using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickableItem : MonoBehaviour, IInteractable
{
    private new Renderer renderer;
    private Material originalMaterial;
    public Material highlightMaterial;
    public ItemSO item;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;

        if (item == null) // Check if item is assigned
        {
            Debug.LogError("ItemSO is not assigned to PickableItem!");
        }
    }

    public void Interact()
    {
        if (item == null) // Check if item is assigned before using it
        {
            Debug.LogError("ItemSO is null in Interact!");
            return;
        }

        Debug.Log($"Picked up: {item.name}"); // Log the item name for clarity
        gameObject.SetActive(false); // Deactivate the item

        // Additional feedback (e.g., audio or particles) can be added here
    }

    public void Highlight(bool highlight)
    {
        if (renderer == null)
        {
            Debug.LogError("Renderer is null in Highlight!");
            return;
        }
        renderer.material = highlight ? highlightMaterial : originalMaterial;
        Debug.Log($"Highlighting: {name} - {highlight}");
    }
}

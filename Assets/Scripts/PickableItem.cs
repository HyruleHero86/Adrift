using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Item has been picked up!");
        InventoryManager.instance.AddItem(item); // Adjusted to use ItemSO
        gameObject.SetActive(false); // Deactivate the item
    }

    public void Highlight(bool highlight)
    {
        renderer.material = highlight ? highlightMaterial : originalMaterial;
    }

}

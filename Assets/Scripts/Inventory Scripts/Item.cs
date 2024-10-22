using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemData; // Reference to the Item ScriptableObject

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemData);
            gameObject.SetActive(false);
        }
    }
}


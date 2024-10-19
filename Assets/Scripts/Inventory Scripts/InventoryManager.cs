using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; 

    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot; // Array of ItemSlot
    public Transform holdPoint; // Reference to the hold point

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ensures no duplicates
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1; // Time resumes
            InventoryMenu.SetActive(false); // Deactivate the menu
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0; // Pauses game when looking at inventory
            InventoryMenu.SetActive(true); // Activate the menu
            menuActivated = true;
        }
    }

    public void AddItem(ItemSO item) // Adjusted to use ItemSO
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(item); 
                return;
            }
        }
        //if inventory is full, swap items
        SwapItems(item);
    }
    private void SwapItems(ItemSO newItem)
    {
        ItemSO oldItem = itemSlot[0].item; // Get the item from the first slot
        itemSlot[0].ClearSlot(); // Clear the first slot
        itemSlot[0].AddItem(newItem); // Add new item to the first slot

        // Now oldItem is available to be placed elsewhere or in hand
        SelectItem(oldItem);
    }
        public void SelectItem(ItemSO item)
    {
        // Instantiate and attach the item to the hold point
        GameObject itemInstance = Instantiate(item.prefab, holdPoint);
        itemInstance.transform.localPosition = Vector3.zero;
        itemInstance.transform.localRotation = Quaternion.identity;
        Debug.Log(item.name + "is now selected and displayed in hand");
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }

    }
}

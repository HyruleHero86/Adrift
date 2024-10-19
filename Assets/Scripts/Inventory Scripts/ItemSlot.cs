using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ====ITEM DATA========//
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public ItemSO item;

    // =====ITEM SLOT====/
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(ItemSO itemSO)
    {
        this.item = itemSO;
        this.itemName = itemSO.name;
        this.itemSprite = itemSO.icon;
        isFull = true;

        if (itemImage != null)
        {
            itemImage.sprite = itemSprite;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        InventoryManager.instance.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        InventoryManager.instance.SelectItem(item);
    }
    public void OnRightClick()
    {

    }

    public void ClearSlot()
    {
        itemName = "";
        itemSprite = null;
        isFull = false;
        item = null;

        if (itemImage != null)
        {
            itemImage.sprite = null;
        }
    }
}

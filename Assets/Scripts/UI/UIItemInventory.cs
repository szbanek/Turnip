using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject itemsListParent;
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, UIItemSlot> equippedSlots;

    private PlayerItemsInventory inventory;
    private UIItemSlot[] inventorySlots;

    private void Start()
    {
        inventorySlots = itemsListParent.GetComponentsInChildren<UIItemSlot>();
    }

    public void OnMenuEnabled()
    {
        inventory = FindObjectOfType<PlayerItemsInventory>();
        PopulateEquipment();
        PopulateInventory();
    }

    private void PopulateInventory()
    {
        if(inventory.Items.Count > inventorySlots.Length)
        {
            throw new ArgumentOutOfRangeException("Too many items in inventory");
        }
        int i = 0;
        foreach(PlayerItem item in inventory.Items)
        {
            inventorySlots[i].Item = item;
            i++;
        }
    }

    private void PopulateEquipment()
    {
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            equippedSlots[slot].Item = inventory.Slots[slot];
        }
    }
}

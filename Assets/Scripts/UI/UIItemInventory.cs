using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject itemsListParent;
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, UIItemSlot> inventorySlots;

    private PlayerItemsInventory inventory;

    public void OnMenuEnabled()
    {
        inventory = FindObjectOfType<PlayerItemsInventory>();
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            inventorySlots[slot].Item = inventory.Slots[slot];
        }
    }
}

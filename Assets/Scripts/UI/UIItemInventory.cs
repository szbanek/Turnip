using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

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
        print("Items");
        foreach(PlayerItem item in inventory.Items)
        {
            inventorySlots[i].Item = item;
            Debug.Log(item.Mesh.name);
            inventorySlots[i].OnItemPressed -= EquipItem;
            inventorySlots[i].OnItemPressed += EquipItem;
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

    private void EquipItem(object slotObject, PlayerItem item)
    {
        UIItemSlot slot = (UIItemSlot)slotObject;
        PlayerItem.ItemSlotType slotType = item.SlotType;
        PlayerItem currentInSlot = inventory.Slots[slotType];
        inventory.Slots[slotType] = item;
        inventory.UpdateItemsInSlots();
        PopulateEquipment();
        slot.Item = currentInSlot;
        inventory.Items.Remove(item);
        inventory.Items.Add(currentInSlot);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;
using UnityEngine.Localization;

public class UIItemInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject itemsListParent;
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, UIItemSlot> equippedSlots;
    [SerializeField]
    private Text statsText;
    [SerializeField]
    private LocalizedString statsString;

    private PlayerItemsInventory inventory;
    private PlayerStats stats;
    private UIItemSlot[] inventorySlots;

    private void Start()
    {
        inventorySlots ??= itemsListParent.GetComponentsInChildren<UIItemSlot>();
    }

    public void OnMenuEnabled()
    {
        inventory = FindObjectOfType<PlayerItemsInventory>();
        stats = FindObjectOfType<PlayerStats>();
        PopulateEquipment();
        PopulateInventory();
        statsText.text = string.Format(statsString.GetLocalizedString(),
            stats.SprintSpeed,
            stats.MaxStamina,
            stats.StaminaRegen,
            stats.JumpCost,
            stats.AdditionalVegetableChance,
            stats.MinigameBonus,
            stats.SenseRange);
    }

    private void PopulateInventory()
    {
        inventorySlots ??= itemsListParent.GetComponentsInChildren<UIItemSlot>();
        if (inventory.Items.Count > inventorySlots.Length)
        {
            throw new ArgumentOutOfRangeException("Too many items in inventory");
        }
        int i = 0;
        foreach(ItemInstance item in inventory.Items)
        {
            inventorySlots[i].Item = item;
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

    private void EquipItem(object slotObject, ItemInstance item)
    {
        UIItemSlot slot = (UIItemSlot)slotObject;
        PlayerItem.ItemSlotType slotType = item.Item.SlotType;
        ItemInstance currentInSlot = inventory.Slots[slotType];
        inventory.Slots[slotType] = item;
        inventory.UpdateItemsInSlots();
        PopulateEquipment();
        slot.Item = currentInSlot;
        inventory.Items.Remove(item);
        inventory.Items.Add(currentInSlot);
        statsText.text = string.Format(statsString.GetLocalizedString(),
            stats.SprintSpeed,
            stats.MaxStamina,
            stats.StaminaRegen,
            stats.JumpCost,
            stats.AdditionalVegetableChance,
            stats.MinigameBonus,
            stats.SenseRange);
    }
}

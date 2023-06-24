using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, SkinnedMeshRenderer> renderers;

    [Header("Slots")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, ItemInstance> slotsContent;
    public SerializedDictionary<PlayerItem.ItemSlotType, ItemInstance> Slots => slotsContent;

    public List<ItemInstance> Items;

    private PlayerStatsModifier totalModifier;
    public PlayerStatsModifier TotalModifier => totalModifier;

    private void Start()
    {
        UpdateItemsInSlots();
    }

    public void UpdateItemsInSlots()
    {
        totalModifier = new PlayerStatsModifier();
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            renderers[slot].sharedMaterials = slotsContent[slot].Item.Materials;
            renderers[slot].sharedMesh = slotsContent[slot].Item.Mesh;
            totalModifier += slotsContent[slot].Modifier;
        }
    }
}

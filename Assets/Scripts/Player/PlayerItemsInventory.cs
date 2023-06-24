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
    private SerializedDictionary<PlayerItem.ItemSlotType, PlayerItem> slotsContent;
    public SerializedDictionary<PlayerItem.ItemSlotType, PlayerItem> Slots => slotsContent;

    [SerializeField]
    private List<PlayerItem> items;
    public List<PlayerItem> Items => items;

    private void Start()
    {
        UpdateItemsInSlots();
    }

    public void UpdateItemsInSlots()
    {
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            renderers[slot].sharedMaterials = slotsContent[slot].Materials;
            renderers[slot].sharedMesh = slotsContent[slot].Mesh;
        }
    }
}

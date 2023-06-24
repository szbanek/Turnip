using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlot, SkinnedMeshRenderer> headRenderers;

    [Header("Slots")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlot, PlayerItem> slotsContent;

    [SerializeField]
    private List<PlayerItem> items;

    private void Start()
    {
        UpdateItemsInSlots();
    }

    private void UpdateItemsInSlots()
    {
        PlayerItem.ItemSlot[] slots = (PlayerItem.ItemSlot[])Enum.GetValues(typeof(PlayerItem.ItemSlot));
        foreach (PlayerItem.ItemSlot slot in slots)
        {
            headRenderers[slot].sharedMaterials = slotsContent[slot].Materials;
            headRenderers[slot].sharedMesh = slotsContent[slot].Mesh;
        }
    }
}

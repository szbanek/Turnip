using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClothsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, SkinnedMeshRenderer> renderers;

    [Header("Item sets")]
    [SerializeField]
    private SerializedDictionary<PlayerItem.ItemSlotType, List<PlayerItem>> sets;

    private SerializedDictionary<PlayerItem.ItemSlotType, PlayerItem> slotsContent = new SerializedDictionary<PlayerItem.ItemSlotType, PlayerItem>();

    private void Start()
    {
        InitRandomItems();
        UpdateItemsInSlots();
    }

    private void InitRandomItems()
    {
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            slotsContent[slot] = sets[slot][UnityEngine.Random.Range(0, sets[slot].Count)];
        }
    }

    private void UpdateItemsInSlots()
    {
        PlayerItem.ItemSlotType[] slots = (PlayerItem.ItemSlotType[])Enum.GetValues(typeof(PlayerItem.ItemSlotType));
        foreach (PlayerItem.ItemSlotType slot in slots)
        {
            renderers[slot].sharedMaterials = slotsContent[slot].Materials;
            renderers[slot].sharedMesh = slotsContent[slot].Mesh;
        }
    }
}

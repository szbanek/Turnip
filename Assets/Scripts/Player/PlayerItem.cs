using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player item")]
public class PlayerItem : ScriptableObject
{
    public enum ItemSlotType
    {
        Head,
        Body,
        Legs
    }

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Sprite inventoryIcon;
    public Sprite InventoryIcon => inventoryIcon;

    [SerializeField]
    private ItemSlotType slot;
    public ItemSlotType SlotType => slot;

    private SkinnedMeshRenderer meshRenderer; 

    public Mesh Mesh => meshRenderer.sharedMesh;
    public Material[] Materials => meshRenderer.sharedMaterials;

    private void OnValidate()
    {
        if(prefab != null)
        {
            meshRenderer = prefab.GetComponentInChildren<SkinnedMeshRenderer>();
        }
    }
}

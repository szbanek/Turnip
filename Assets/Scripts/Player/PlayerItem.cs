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
    private SkinnedMeshRenderer meshPrefab;
    [SerializeField]
    private Sprite inventoryIcon;
    public Sprite InventoryIcon => inventoryIcon;

    [SerializeField]
    private ItemSlotType slot;

    public Mesh Mesh => meshPrefab.sharedMesh;
    public Material[] Materials => meshPrefab.sharedMaterials;
}

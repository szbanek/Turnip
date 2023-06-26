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
    private string itemName;
    public string ItemName => itemName;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Sprite inventoryIcon;
    public Sprite InventoryIcon => inventoryIcon;

    [SerializeField]
    private ItemSlotType slot;
    public ItemSlotType SlotType => slot;

    private SkinnedMeshRenderer meshRenderer;

    public Mesh Mesh
    { 
        get 
        { 
            if (meshRenderer == null)
            {
                meshRenderer = prefab.GetComponentInChildren<SkinnedMeshRenderer>();
            }
            return meshRenderer.sharedMesh;
        }
    }

    public Material[] Materials 
    { 
        get 
        {
            if (meshRenderer == null)
            {
                meshRenderer = prefab.GetComponentInChildren<SkinnedMeshRenderer>();
            }
            return meshRenderer.sharedMaterials;
        }
    }
}

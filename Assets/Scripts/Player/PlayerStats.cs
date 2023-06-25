using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerItemsInventory))]
[RequireComponent(typeof(PlayerTree))]
public class PlayerStats : MonoBehaviour
{
    [Header("Stamina")]
    [SerializeField]
    private float maxStamina;
    [SerializeField]
    private float staminaRegen;

    [Header("Movement")]
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float jumpCost;

    [Header("Minigames")]
    [SerializeField]
    private float additionalVegetableChance;
    [SerializeField]
    private float minigameBonus;

    [Header("Vegetable sense")]
    [SerializeField]
    private float senseRange;

    private PlayerItemsInventory inventory;
    private PlayerTree playerTree;

    private void Awake()
    {
        inventory = GetComponent<PlayerItemsInventory>();
        playerTree = GetComponent<PlayerTree>();
    }

    public float MaxStamina => maxStamina + inventory.TotalModifier.MaxStamina + playerTree.Stats.MaxStamina;
    public float StaminaRegen => staminaRegen + inventory.TotalModifier.StaminaRegen + playerTree.Stats.StaminaRegen;
    public float SprintSpeed => sprintSpeed + inventory.TotalModifier.SprintSpeed + playerTree.Stats.SprintSpeed;
    public float JumpCost => jumpCost + inventory.TotalModifier.JumpCost + playerTree.Stats.JumpCost;
    public float AdditionalVegetableChance => additionalVegetableChance + inventory.TotalModifier.AdditionalVegetableChance + playerTree.Stats.AdditionalVegetableChance;
    public float MinigameBonus => minigameBonus + inventory.TotalModifier.MinigameBonus + playerTree.Stats.MinigameBonus;
    public float SenseRange => senseRange + inventory.TotalModifier.SenseRange + playerTree.Stats.SenseRange;
}

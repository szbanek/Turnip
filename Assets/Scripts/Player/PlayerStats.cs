using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerItemsInventory))]
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

    private PlayerItemsInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<PlayerItemsInventory>();
    }

    public float MaxStamina => maxStamina + inventory.TotalModifier.MaxStamina;
    public float StaminaRegen => staminaRegen + inventory.TotalModifier.StaminaRegen;
    public float SprintSpeed => sprintSpeed + inventory.TotalModifier.SprintSpeed;
    public float JumpCost => jumpCost + inventory.TotalModifier.JumpCost;
    public float AdditionalVegetableChance => additionalVegetableChance + inventory.TotalModifier.AdditionalVegetableChance;
    public float MinigameBonus => minigameBonus + inventory.TotalModifier.MinigameBonus;
}

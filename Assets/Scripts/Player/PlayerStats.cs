using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stamina")]
    public float MaxStamina;
    public float StaminaRegen;

    [Header("Movement")]
    public float SprintSpeed;
    public float JumpCost;

    [Header("Sense")]
    public bool HasSense;
    public float SenseRange;

    [Header("Minigames")]
    public float AdditionalVegetableChance;
    public float MinigameBonus;

    [Header("Trade")]
    public float TradeBonus;
}

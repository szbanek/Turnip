using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerExperience))]
public class PlayerTree : MonoBehaviour
{
    public enum Choice { MaxStanima, StaminaRegen, SprintSpeed, JumpCost, AdditionalVegetableChance, MinigameBonus, SenseRange }

    [SerializeField]
    private SerializedDictionary<Choice, float> amountGiven;
    [SerializeField]
    private SerializedDictionary<Choice, int> levels;

    public PlayerStatsModifier Stats => stats;
    public SerializedDictionary<Choice, int> Levels => levels;

    private PlayerStatsModifier stats = new PlayerStatsModifier();

    private PlayerExperience playerExperience;

    private void Start()
    {
        playerExperience = GetComponent<PlayerExperience>();
    }

    public void TryToLevelUp(Choice choice)
    {
        if (playerExperience.AvailablePoints - 1 < 0)
        {
            return;
        }
        playerExperience.SubtractPoints(1);
        levels[choice] += 1;
        switch (choice)
        {
            case Choice.MaxStanima:
                stats.MaxStamina += amountGiven[choice];
                break;
            case Choice.StaminaRegen:
                stats.StaminaRegen += amountGiven[choice];
                break;
            case Choice.SprintSpeed:
                stats.SprintSpeed += amountGiven[choice];
                break;
            case Choice.JumpCost:
                stats.JumpCost += amountGiven[choice];
                break;
            case Choice.AdditionalVegetableChance:
                stats.AdditionalVegetableChance += amountGiven[choice];
                break;
            case Choice.MinigameBonus:
                stats.MinigameBonus += amountGiven[choice];
                break;
            case Choice.SenseRange:
                stats.SenseRange += amountGiven[choice];
                break;
        }
    }
}

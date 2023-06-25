using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerStatsModifier
{
    public float MaxStamina = 0;
    public float StaminaRegen = 0;
    public float SprintSpeed = 0;
    public float JumpCost = 0;
    public float SenseRange = 0;
    public float AdditionalVegetableChance = 0;
    public float MinigameBonus = 0;

    public static PlayerStatsModifier operator+(PlayerStatsModifier a, PlayerStatsModifier b)
    {
        PlayerStatsModifier value = new PlayerStatsModifier();
        value.MaxStamina = a.MaxStamina + b.MaxStamina;
        value.StaminaRegen = a.StaminaRegen + b.StaminaRegen;
        value.SprintSpeed = a.SprintSpeed + b.SprintSpeed;
        value.JumpCost = a.JumpCost + b.JumpCost;
        value.SenseRange = a.SenseRange + b.SenseRange;
        value.AdditionalVegetableChance = a.AdditionalVegetableChance + b.AdditionalVegetableChance;
        value.MinigameBonus = a.MinigameBonus + b.MinigameBonus;
        return value;
    }

    public override string ToString()
    {
        string res = "";
        if (MaxStamina != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Maksymalna kondycja: " + MaxStamina.ToString();
        }
        if (StaminaRegen != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Regeneracja kondycji: " + StaminaRegen.ToString();
        }
        if (SprintSpeed != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Szybkość biegu: " + SprintSpeed.ToString();
        }
        if (JumpCost != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Koszt skoku: " + JumpCost.ToString();
        }
        if (SenseRange != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Zasięg zmysłów: " + SenseRange.ToString();
        }
        if (AdditionalVegetableChance != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Szansa na dodatkowe warzywo: " + AdditionalVegetableChance.ToString();
        }
        if (MinigameBonus != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += "Umiejętności zbierackie: " + MinigameBonus.ToString();
        }
        return res;
    }
}

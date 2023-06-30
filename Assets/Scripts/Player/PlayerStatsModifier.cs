using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;

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
        LocalizedStringTable localizedStringTable = new LocalizedStringTable { TableReference = "Strings" };
        var stringTable = localizedStringTable.GetTable();
        string res = "";
        if (MaxStamina != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("max_stamina").GetLocalizedString() + ": " + MaxStamina.ToString("f2");
        }
        if (StaminaRegen != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("stamina_regen").GetLocalizedString() + ": " + StaminaRegen.ToString("f2");
        }
        if (SprintSpeed != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("sprint_speed").GetLocalizedString() + ": " + SprintSpeed.ToString("f2");
        }
        if (JumpCost != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("jump_cost").GetLocalizedString() + ": " + JumpCost.ToString("f2");
        }
        if (SenseRange != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("veg_sense_range").GetLocalizedString() + ": " + SenseRange.ToString("f2");
        }
        if (AdditionalVegetableChance != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("add_veg_chance").GetLocalizedString() + ": " + AdditionalVegetableChance.ToString("f2");
        }
        if (MinigameBonus != 0)
        {
            if (res.Length > 0)
            {
                res += "\n";
            }
            res += stringTable.GetEntry("gathering_skill").GetLocalizedString() + ": " + MinigameBonus.ToString("f2");
        }
        return res;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ItemsGenerator : Singleton<ItemsGenerator>
{
    [SerializeField]
    private Vector2 itemStatRange;
    [SerializeField]
    private PlayerItem[] itemsPrefabs;
    [SerializeField]
    private string[] adjectives;

    public string RandomAdjective => adjectives[UnityEngine.Random.Range(0, adjectives.Length - 1)];

    public ItemInstance GenerateItem(PlayerItem item)
    {
        PlayerStatsModifier statsModifier = new PlayerStatsModifier();
        var choices = Enum.GetValues(typeof(PlayerTree.Choice));
        switch ((PlayerTree.Choice)choices.GetValue(UnityEngine.Random.Range(0, choices.Length - 1)))
        {
            case PlayerTree.Choice.MaxStanima:
                statsModifier.MaxStamina = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
            case PlayerTree.Choice.StaminaRegen:
                statsModifier.StaminaRegen = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
            case PlayerTree.Choice.SprintSpeed:
                statsModifier.SprintSpeed = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
            case PlayerTree.Choice.JumpCost:
                statsModifier.JumpCost = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
            case PlayerTree.Choice.AdditionalVegetableChance:
                statsModifier.AdditionalVegetableChance = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
            case PlayerTree.Choice.MinigameBonus:
                statsModifier.MinigameBonus = UnityEngine.Random.Range(itemStatRange.x, itemStatRange.y);
                break;
        }
        ItemInstance instance = new ItemInstance(item, statsModifier, RandomAdjective + " " + item.ItemName);
        return instance;
    }

    public ItemInstance GenerateItem()
    {
        PlayerItem item = itemsPrefabs[UnityEngine.Random.Range(0, itemsPrefabs.Length)];
        return GenerateItem(item);
    }
}

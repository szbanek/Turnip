using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public PlayerItem Item;
    public PlayerStatsModifier Modifier;

    public string Name => ItemsGenerator.Instance.GetAdjective(adjIndex) + " " + Item.ItemName;
    public string Description => Modifier.ToString();

    private int adjIndex;

    public ItemInstance(PlayerItem item, PlayerStatsModifier modifier, int adjIndex)
    {
        Item = item;
        Modifier = modifier;
        this.adjIndex = adjIndex;
    }
}

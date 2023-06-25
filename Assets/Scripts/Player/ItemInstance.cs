using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public PlayerItem Item;
    public PlayerStatsModifier Modifier;

    public string Name;
    public string Description => Modifier.ToString();

    public ItemInstance(PlayerItem item, PlayerStatsModifier modifier, string name)
    {
        Item = item;
        Modifier = modifier;
        Name = name;
    }
}

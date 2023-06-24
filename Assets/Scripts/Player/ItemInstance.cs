using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public PlayerItem Item;
    public PlayerStatsModifier Modifier;

    public ItemInstance(PlayerItem item, PlayerStatsModifier modifier)
    {
        Item = item;
        Modifier = modifier;
    }
}

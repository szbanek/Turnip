using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : Singleton<ItemsGenerator>
{
    [SerializeField]
    private GameObject[] itemsPrefabs;

    public ItemInstance GenerateItem()
    {
        PlayerItem item = itemsPrefabs[Random.Range(0, itemsPrefabs.Length)].GetComponent<PlayerItem>();
        PlayerStatsModifier statsModifier = new PlayerStatsModifier();
        statsModifier.SprintSpeed = Random.Range(0, 10);
        ItemInstance instance = new ItemInstance(item, statsModifier);
        return instance;
    }
}

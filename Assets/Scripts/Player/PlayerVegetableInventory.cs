using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVegetableInventory : MonoBehaviour
{
    [SerializeField]
    private SerializedDictionary<Vegetable.VegetableType, int> inventory = new SerializedDictionary<Vegetable.VegetableType, int>();

    public SerializedDictionary<Vegetable.VegetableType, int> Inventory => inventory;

    public void AddItem(Vegetable.VegetableType type, int amount)
    {
        inventory[type] += amount;
    }

    public bool TryRemoveItem(Vegetable.VegetableType type, int amount)
    {
        if (inventory[type] >= amount)
        {
            inventory[type] -= amount;
            return true;
        }
        return false;
    }
}

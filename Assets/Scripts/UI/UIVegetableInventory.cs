using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVegetableInventory : MonoBehaviour
{
    [SerializeField]
    private List<UIVegetableSlot> slots;

    public void UpdateVegetable(Vegetable.VegetableType type, int amount)
    {
        slots.Find((e) => e.VegetableType == type).SetAmount(amount);
    }
}

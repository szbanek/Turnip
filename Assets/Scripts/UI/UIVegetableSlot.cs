using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVegetableSlot : MonoBehaviour
{
    [SerializeField]
    private Vegetable vegetable;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text amountText;
    [SerializeField]
    private Text vegetableName;
    [SerializeField]
    private Text vegetableDescription;

    public Vegetable.VegetableType VegetableType => vegetable.Type;

    private void OnValidate()
    {
        if (vegetable != null)
        {
            if (icon != null)
            {
                icon.sprite = vegetable.Icon;
            }
            if (vegetableName != null)
            {
                vegetableName.text = vegetable.Name;
            }
            if (vegetableDescription != null)
            {
                vegetableDescription.text = vegetable.Description;
            }
        }
    }

    public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
    }
}

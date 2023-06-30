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

    private void OnEnable()
    {
        icon.sprite = vegetable.Icon;
        vegetableName.text = vegetable.Name;
        vegetableDescription.text = vegetable.Description;
    }

    public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
    }
}

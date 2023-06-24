using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public Quest
    (
        Vegetable.VegetableType type,
        int quantity,
        string text
        // items
    )
    {
        this.type = type;
        this.quantity = quantity;
        this.text = text;
        text.Replace("{NAME}", Vegetable.TypeToString(type));
        text.Replace("{QUANTITY}", quantity.ToString());
        Debug.Log(text);
    }
    private Vegetable.VegetableType type;
    public Vegetable.VegetableType Type => type;
    private int quantity;
    public int Quantity => quantity;
    private string text;
    public string Text => text;
}
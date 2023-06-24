using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public Quest
    (
        Vegetable.VegetableType type,
        int quantity,
        string text,
        string positiveAnswer,
        string negativeAnswer
        // items
    )
    {
        this.type = type;
        this.quantity = quantity;
        this.text = text;
        this.text = this.text.Replace("{NAME}", Vegetable.TypeToString(type));
        this.text = this.text.Replace("{QUANTITY}", quantity.ToString());
        Debug.Log(text);
        this.positiveAnswer = positiveAnswer;
        this.positiveAnswer = this.positiveAnswer.Replace("{NAME}", Vegetable.TypeToString(type));
        this.positiveAnswer = this.positiveAnswer.Replace("{QUANTITY}", quantity.ToString());
        this.negativeAnswer = negativeAnswer;
        this.negativeAnswer = this.negativeAnswer.Replace("{NAME}", Vegetable.TypeToString(type));
        this.negativeAnswer = this.negativeAnswer.Replace("{QUANTITY}", quantity.ToString());
    }
    private Vegetable.VegetableType type;
    public Vegetable.VegetableType Type => type;
    private int quantity;
    public int Quantity => quantity;
    private string text;
    public string Text => text;
    private string positiveAnswer;
    public string PositiveAnswer => positiveAnswer;
    private string negativeAnswer;
    public string NegativeAnswer => negativeAnswer;
}
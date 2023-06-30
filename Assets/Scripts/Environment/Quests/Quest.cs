using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public Quest
    (
        Vegetable.VegetableType type,
        int quantity,
        QuestText questText,
        float exp,
        ItemInstance item
    )
    {
        this.type = type;
        this.quantity = quantity;
        this.questText = questText;
        this.exp = exp;
        this.item = item;
    }
    private Vegetable.VegetableType type;
    public Vegetable.VegetableType Type => type;
    private int quantity;
    public int Quantity => quantity;
    private QuestText questText;
    public string Text => questText.Text;

    public string PositiveAnswer => questText.PositiveAnswer;

    public string NegativeAnswer => questText.NegativeAnswer;

    private float exp;
    public float Exp => exp;
    private ItemInstance item;
    public ItemInstance Item => item;
}
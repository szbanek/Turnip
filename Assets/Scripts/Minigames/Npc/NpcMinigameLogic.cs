using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcMinigameLogic : MonoBehaviour
{
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private Quest quest;
    private NpcMinigameButton button;
    private NpcMinigameText textField;
    private PlayerVegetableInventory inventory;
    private bool done = false;

    public void Click(Vector2 vector)
    {
        RectTransform rectTransform = button.transform as RectTransform;
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(vector);
        if (rectTransform.rect.Contains(localMousePosition) && !done)
        {
            if (inventory.TryRemoveItem(quest.Type, quest.Quantity))
            {
                done = true;
                textField.ChangeText(quest.PositiveAnswer);
                button.ChangeText("");
            }
            else
            {
                textField.ChangeText(quest.NegativeAnswer);

            }
        }
        else
        {
            if (done) OnWinEvent?.Invoke(this, null);
            else OnLoseEvent?.Invoke(this, null);
        }
    }
    private void Start()
    {
        inventory = FindObjectOfType<PlayerVegetableInventory>();
    }

    private void HandleEvent(bool win)
    {
        if (win) OnWinEvent?.Invoke(this, null);
        else OnLoseEvent?.Invoke(this, null);
    }
    public void NewButton(NpcMinigameButton button)
    {
        this.button = button;
    }

    public void NewTextField(NpcMinigameText textField)
    {
        this.textField = textField;
    }

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        textField.ChangeText(quest.Text);
        button.ChangeText($"Daj {quest.Quantity} {Vegetable.TypeToString(quest.Type)}");
    }
}

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
        if(done) return;
        RectTransform rectTransform = button.transform as RectTransform;
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(vector);
        if (rectTransform.rect.Contains(localMousePosition))
        {
            if(inventory.TryRemoveItem(quest.Type, quest.Quantity))
            {
                done = true;
                textField.ChangeText(quest.PositiveAnswer);
            }
            else
            {
                textField.ChangeText(quest.NegativeAnswer);
            }
        }
    }
    private void Start()
    {
        quest = QuestManager.Instance.GetNewQuest();
        inventory = FindObjectOfType<PlayerVegetableInventory>();
    }

    private void HandleEvent(bool win)
    {
        if (win) OnWinEvent?.Invoke(this, null);
        else OnLoseEvent?.Invoke(this, null);
    }
    public string GetButtonText(NpcMinigameButton button)
    {
        this.button = button;
        return $"Daj {quest.Quantity} {quest.Type}";
    }

    public void NewTextField(NpcMinigameText textField)
    {
        this.textField = textField;
        this.textField.ChangeText(quest.Text);
    }
}

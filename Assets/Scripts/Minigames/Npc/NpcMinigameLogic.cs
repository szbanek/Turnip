using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class NpcMinigameLogic : MonoBehaviour
{
    [SerializeField]
    private RandomSoundPlayer introPlayer;
    [SerializeField]
    private RandomSoundPlayer acceptPlayer;
    [SerializeField]
    private RandomSoundPlayer refusePlayer;
    [SerializeField]
    private LocalizedString giveString;

    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private Quest quest;
    private NpcMinigameButton button;
    private NpcMinigameText textField;
    private PlayerVegetableInventory inventory;
    private bool done = false;

    private string intro = ""; 
    private string positive = "";
    private string negative = "";
    private string buttonText = "";

    public void Click(Vector2 vector)
    {
        RectTransform rectTransform = button.transform as RectTransform;
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(vector);
        if (rectTransform.rect.Contains(localMousePosition) && !done)
        {
            if (inventory.TryRemoveItem(quest.Type, quest.Quantity))
            {
                done = true;
                textField.ChangeText(positive);
                acceptPlayer.PlayRandom();
                button.ChangeText("");
            }
            else
            {
                textField.ChangeText(negative);
                refusePlayer.PlayRandom();
            }
        }
        else
        {
            if (done) OnWinEvent?.Invoke(this, null);
            else OnLoseEvent?.Invoke(this, null);
        }
    }
    private IEnumerator Start()
    {
        inventory = FindObjectOfType<PlayerVegetableInventory>();
        introPlayer.PlayRandom();
        yield return new WaitUntil(() => quest != null);
        LocalizedStringTable localizedStringTable = new LocalizedStringTable { TableReference = "Strings" };
        string vegetableName = localizedStringTable.GetTable().GetEntry(quest.Type.ToString().ToLower()).GetLocalizedString();

        intro = quest.Text.Replace("{NAME}", vegetableName).Replace("{QUANTITY}", quest.Quantity.ToString());
        positive = quest.PositiveAnswer.Replace("{NAME}", vegetableName).Replace("{QUANTITY}", quest.Quantity.ToString());
        negative = quest.NegativeAnswer.Replace("{NAME}", vegetableName).Replace("{QUANTITY}", quest.Quantity.ToString());
        buttonText = giveString.GetLocalizedString() + " " + quest.Quantity.ToString() + " " + vegetableName;

        textField.ChangeText(intro);
        button.ChangeText(buttonText);
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
    }
}

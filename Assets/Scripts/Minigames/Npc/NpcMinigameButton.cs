using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NpcMinigameButton : MonoBehaviour
{
    [SerializeField]
    private NpcMinigameLogic logic;
    private Text textField;
    private void Awake()
    {
        textField = GetComponent<Text>();
        if (logic == null)
        {
            logic = GetComponentInParent<NpcMinigameLogic>();
        }
        logic.NewButton(this);
    }

    public void ChangeText(String text)
    {
        textField.text = text;
    }
}
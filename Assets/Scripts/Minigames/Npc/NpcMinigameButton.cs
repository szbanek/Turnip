using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcMinigameButton : MonoBehaviour
{
    [SerializeField]
    private NpcMinigameLogic logic;
    private String buttonText;
    private void Start()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<NpcMinigameLogic>();
        }
        buttonText = logic.GetButtonText(this);
    }
}
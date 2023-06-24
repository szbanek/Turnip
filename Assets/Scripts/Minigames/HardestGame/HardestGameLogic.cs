using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardestGameLogic : MonoBehaviour
{
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private HardestGameItem lettuce;
    private Vector2 position;


    public void UpdatePos(Vector2 vector)
    {
        position = vector;
        lettuce.UpdatePos(vector);
    }
    public void Pull(bool up)
    {
        if (!up)
        {
            lettuce.SetHeld(false);
            return;
        }
        RectTransform rectTransform = lettuce.transform as RectTransform;
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(position);
        if (rectTransform.rect.Contains(localMousePosition))
        {
            lettuce.SetHeld(true);
        }
    }

    private void Start()
    {
        lettuce.OnGoalReachedEvent += (_, win) => HandleEvent(win);
    }

    private void HandleEvent(bool win)
    {
        if(win) OnWinEvent?.Invoke(this, null);
        else OnLoseEvent?.Invoke(this, null);
    }


    public void NewLettuce(HardestGameItem lettuce)
    {
        this.lettuce = lettuce;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamUpManager : MonoBehaviour, IMinigameManager
{
    private SpamUpInputAdadpter adadpter;
    public event EventHandler<bool> OnMinigameEndEvent;
    public void EndMinigame(bool win)
    {
        Debug.Log(win);
        adadpter.Stopped = true;
        OnMinigameEndEvent?.Invoke(this, win);
    }

    private void Start()
    {
        adadpter = GetComponent<SpamUpInputAdadpter>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpManager : MonoBehaviour, IMinigameManager
{
    private PullUpInputAdadpter adadpter;
    public event EventHandler<bool> OnMinigameEndEvent;
    public void EndMinigame(bool win)
    {
        adadpter.Stopped = true;
        OnMinigameEndEvent?.Invoke(this, win);
    }

    private void Start()
    {
        adadpter = GetComponent<PullUpInputAdadpter>();
    }
}

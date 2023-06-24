using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMinigameManager : MonoBehaviour, IMinigameManager
{
    private NpcMinigameInputAdapter adadpter;
    public event EventHandler<bool> OnMinigameEndEvent;
    private void Start()
    {
        adadpter = GetComponent<NpcMinigameInputAdapter>();
        adadpter.OnAnyClick += (_,_) => EndMinigame(false);
    }
    private void EndMinigame(bool win)
    {
        if(win) Debug.Log("You won");
        if(!win) Debug.Log("You lost");
        OnMinigameEndEvent?.Invoke(this, win);
    }
}

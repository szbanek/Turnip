using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdClickManager : MonoBehaviour, IMinigameManager
{
    private WasdClickInputAdapter adadpter;
    private WasdClickLogic logic;
    public event EventHandler<bool> OnMinigameEndEvent;
    private void Start()
    {
        adadpter = GetComponent<WasdClickInputAdapter>();
        logic = GetComponent<WasdClickLogic>();
        logic.OnLoseEvent += (_,_) => EndMinigame(false);
        logic.OnWinEvent += (_,_) => EndMinigame(true);
    }
    private void EndMinigame(bool win)
    {
        if(win) Debug.Log("You won");
        if(!win) Debug.Log("You lost");
        adadpter.Stopped = true;
        OnMinigameEndEvent?.Invoke(this, win);
    }

    public void SetDifficulty(float difficulty)
    {
        throw new NotImplementedException();
    }
}

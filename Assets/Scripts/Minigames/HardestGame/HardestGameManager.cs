using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardestGameManager : MonoBehaviour, IMinigameManager
{
    private HardestGameInputAdapter adadpter;
    private HardestGameLogic logic;
    public event EventHandler<bool> OnMinigameEndEvent;
    private void Start()
    {
        adadpter = GetComponent<HardestGameInputAdapter>();
        logic = GetComponent<HardestGameLogic>();
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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMultipleManager : MonoBehaviour, IMinigameManager
{
    private ClickMultipleInputAdapter adadpter;
    private ClickMultipleLogic logic;
    public event EventHandler<bool> OnMinigameEndEvent;
    private void Awake()
    {
        adadpter = GetComponent<ClickMultipleInputAdapter>();
        logic = GetComponent<ClickMultipleLogic>();
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
        logic.SetDifficulty(difficulty);
    }
    public void SetQuest(Quest quest)
    {
        return;
    }
}

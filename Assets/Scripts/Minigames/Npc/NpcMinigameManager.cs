using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMinigameManager : MonoBehaviour, IMinigameManager
{
    private NpcMinigameInputAdapter adadpter;
    private NpcMinigameLogic logic;
    public event EventHandler<bool> OnMinigameEndEvent;
    private void Awake()
    {
        adadpter = GetComponent<NpcMinigameInputAdapter>();
        logic = GetComponent<NpcMinigameLogic>();
        logic.OnLoseEvent += (_,_) => EndMinigame(false);
        logic.OnWinEvent += (_,_) => EndMinigame(true);
    }
    private void EndMinigame(bool win)
    {
        if(win) Debug.Log("You won");
        if(!win) Debug.Log("You lost");
        OnMinigameEndEvent?.Invoke(this, win);
    }

    public void SetDifficulty(float difficulty)
    {
        // logic.SetDifficulty(difficulty);
    }
    public void SetQuest(Quest quest)
    {
        logic.SetQuest(quest);
    }
}

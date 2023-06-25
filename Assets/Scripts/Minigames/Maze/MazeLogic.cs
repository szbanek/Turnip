using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeLogic : MonoBehaviour
{
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private MazeItem lettuce;

    public void NotMoving()
    {
        lettuce.NotMoving();
    }

    public void SetMovement(bool left)
    {
        lettuce.SetMovement(left);
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


    public void NewLettuce(MazeItem lettuce)
    {
        this.lettuce = lettuce;
    }

    public void SetDifficulty(float difficulty)
    {
        lettuce.SetDifficulty(difficulty);
    }
}

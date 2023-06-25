using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchLogic : MonoBehaviour
{
    [SerializeField]
    private UIBarController counter;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private CatchBar bar;
    private List<CatchItem> lettuces = new List<CatchItem>();
    private int clickedlettuces = 0;


    private void Start()
    {
        counter.ChangeValue(0, 1);
    }

    public void NewLettuce(CatchItem lettuce)
    {
        lettuces.Add(lettuce);
        lettuce.OnPulledUpEvent += (_, e) => LettucePulledUp(e);
    }

    private void LettucePulledUp(bool win)
    {
        if(!win) 
        {
            OnLoseEvent?.Invoke(this, null);
            return;
        }
        clickedlettuces++;
        counter.ChangeValue(clickedlettuces, lettuces.Count);
        if (clickedlettuces >= lettuces.Count)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    public void SetDifficulty(float difficulty)
    {
        foreach (CatchItem lettuce in lettuces) lettuce.SetDifficulty(difficulty);
    }

    public void NewBar(CatchBar bar)
    {
        this.bar = bar;
    }

    public void UpdatePos(Vector2 vector)
    {
        bar.UpdatePos(vector);
    }
}

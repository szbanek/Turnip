using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardestGameLogic : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
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

    private void StartManual()
    {
        lettuce.OnGoalReachedEvent += (_, win) => HandleEvent(win);
        timer.ChangeValueInverted(0, 1);
        StartCoroutine(TimeCourutine());
    }

    private IEnumerator TimeCourutine()
    {
        float counter = 0;
        while ((counter += Time.deltaTime) < timeLimit)
        {
            timer.ChangeValueInverted(counter, timeLimit);
            yield return null;
        }
        OnLoseEvent?.Invoke(this, null);
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

    public void SetDifficulty(float difficulty)
    {
        timeLimit += difficulty;
        StartManual();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullUpLogic : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<PullUpItem> carrots;
    private Vector2 position;
    private int pulledUpCarrots = 0;


    public void UpdatePos(Vector2 vector)
    {
        position = vector;
        foreach(PullUpItem carrot in carrots)
        {
            carrot.UpdatePos(vector);
        }
    }
    public void Pull(bool up)
    {
        if(!up)
        {
            foreach (PullUpItem carrot in carrots) carrot.SetHeld(false);
            return;
        }
        foreach (PullUpItem carrot in carrots)
        {
            RectTransform rectTransform = carrot.transform as RectTransform;
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(position);
            if (rectTransform.rect.Contains(localMousePosition))
            {
                carrot.SetHeld(true);
            }
        }
    }

    private void Awake()
    {
        carrots = new List<PullUpItem>();
    }
    private void StartManual()
    {
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

    public void NewCarrot(PullUpItem carrot)
    {
        carrots.Add(carrot);
        carrot.OnPulledUpEvent += (_, _) => CarrotPulledUp();
    }

    private void CarrotPulledUp()
    {
        pulledUpCarrots++;
        if (pulledUpCarrots >= carrots.Count)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    public void SetDifficulty(float difficulty)
    {
        timeLimit += difficulty;
        StartManual();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickLogic : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<ClickItem> peppers= new List<ClickItem>();
    private int clickedPeppers = 0;


    public void Pull(Vector2 position)
    {
        foreach (ClickItem pepper in peppers)
        {
            RectTransform rectTransform = pepper.transform as RectTransform;
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(position);
            if (rectTransform.rect.Contains(localMousePosition))
            {
                pepper.Click();
            }
        }
    }
    private void StartManual()
    {
        timer.ChangeValueInverted(0, 1);
        StartCoroutine(TimeCourutine());
        print(peppers.Count);
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

    public void NewPepper(ClickItem pepper)
    {
        peppers.Add(pepper);
        pepper.OnPulledUpEvent += (_, _) => PepperPulledUp();
    }

    private void PepperPulledUp()
    {
        clickedPeppers++;
        if (clickedPeppers >= peppers.Count)
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

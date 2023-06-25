using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMultipleLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController clickCounter;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<ClickMultipleItem> peppers;
    private int clickedPeppers = 0;


    public void Pull(Vector2 position)
    {
        foreach (ClickMultipleItem pepper in peppers)
        {
            RectTransform rectTransform = pepper.transform as RectTransform;
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(position);
            if (rectTransform.rect.Contains(localMousePosition))
            {
                pepper.clickMultiple();
            }
        }
    }

    private void Awake()
    {
        peppers = new List<ClickMultipleItem>();
    }
    private void StartManual()
    {
        clickCounter.ChangeValue(0, 1);
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

    public void NewPepper(ClickMultipleItem pepper)
    {
        peppers.Add(pepper);
        pepper.OnPulledUpEvent += (_, _) => PepperPulledUp();
    }

    private void PepperPulledUp()
    {
        clickedPeppers++;
        clickCounter.ChangeValue(clickedPeppers, requiredClicks);
        if (clickedPeppers >= requiredClicks)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    public void SetDifficulty(float difficulty)
    {
        requiredClicks = (int)(Math.Max(requiredClicks - difficulty, 1));
        timeLimit += difficulty;
        foreach (ClickMultipleItem pepper in peppers) pepper.SetDifficulty(difficulty);
        StartManual();
    }
}

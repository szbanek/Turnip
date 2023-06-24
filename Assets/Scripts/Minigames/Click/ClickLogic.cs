using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickLogic : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 10;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<ClickItem> peppers;
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

    private void Awake()
    {
        peppers = new List<ClickItem>();
    }
    private void Start()
    {
        StartCoroutine(TimeCourutine());
    }

    private IEnumerator TimeCourutine()
    {
        yield return new WaitForSeconds(timeLimit);
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
}

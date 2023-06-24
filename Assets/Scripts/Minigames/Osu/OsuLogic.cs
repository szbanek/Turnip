using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsuLogic : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float hitAccuracy = 0.5f;
    // [SerializeField]
    // private UIBarController timer;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<OsuItem> peppers;
    private int clickedPeppers = 0;


    public void Click(Vector2 position)
    {
        foreach (OsuItem pepper in peppers)
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
        peppers = new List<OsuItem>();
    }
    private void Start()
    {
        // timer.ChangeValueInverted(0, 1);
        peppers[clickedPeppers].StartAction(speed, hitAccuracy);
    }


    public void NewPepper(OsuItem pepper)
    {
        peppers.Add(pepper);
        pepper.OnPulledUpEvent += (_, succes) => PepperPulledUp(succes);
    }

    private void PepperPulledUp(bool succes)
    {
        if (!succes)
        {
            OnLoseEvent?.Invoke(this, null);
            return;
        }
        clickedPeppers++;
        if (clickedPeppers >= peppers.Count)
        {
            OnWinEvent?.Invoke(this, null);
        }
        else
        {
            peppers[clickedPeppers].StartAction(speed, hitAccuracy);
        }
    }
}

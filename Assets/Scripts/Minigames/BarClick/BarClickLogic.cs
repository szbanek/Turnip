using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarClickLogic : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float hitBarSize = 0.2f;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private float minimum = -1.0f;
    private float maximum = 1.0f;
    private float t = 0f;
    private float barValue = 0f;

    public void Click()
    {
        if (Math.Abs(barValue) < hitBarSize)
        {
            OnWinEvent?.Invoke(this, null);
        }
        else
        {
            OnLoseEvent?.Invoke(this, null);
        }
    }

    private void Update()
    {
        barValue = Mathf.Lerp(minimum, maximum, t);

        t += 0.5f * Time.deltaTime * speed;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}

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
    [SerializeField]
    private RectTransform bar;
    [SerializeField]
    private RectTransform sweetSpot;
    [SerializeField]
    private RectTransform carrot;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private float minimum = -1.0f;
    private float maximum = 1.0f;
    private float t = 0f;
    private float barValue = 0f;
    private Vector2 xRange = Vector2.zero;

    private void Start()
    {
        Vector2 anchorMax = sweetSpot.anchorMax;
        Vector2 anchorMin = sweetSpot.anchorMin;
        anchorMax.x = 0.5f + hitBarSize / 2;
        anchorMin.x = 0.5f - hitBarSize / 2;
        sweetSpot.anchorMax = anchorMax;
        sweetSpot.anchorMin = anchorMin;
        xRange.x = bar.rect.xMin;
        xRange.y = bar.rect.xMax;
    }

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
        float xPos = Mathf.Lerp(xRange.x, xRange.y, (barValue + 1) / 2);
        Vector3 pos = carrot.localPosition;
        pos.x = xPos;
        carrot.localPosition = pos;

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

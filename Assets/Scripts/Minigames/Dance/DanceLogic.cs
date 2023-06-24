using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float hitAccuracy = 0.5f;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<ad> arrows;
    private int currentClicks = 0;
    private float minimum = -1.0f;
    private float maximum;
    private float t = 0f;
    private float barValue = 0f;
    private enum ad
    {
        a, d
    }

    public void Click(String key)
    {
        if (key == arrows[currentClicks].ToString() && Math.Abs(barValue - currentClicks) < hitAccuracy)
        {
            currentClicks++;
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
            else
            {
                Debug.Log(arrows[currentClicks]);
            }
        }
        else
        {
            OnLoseEvent?.Invoke(this, null);
        }
    }

    private void Start()
    {
        maximum = requiredClicks + 1;
        arrows = new List<ad>();
        for (int i = 0; i < requiredClicks; i++)
        {
            arrows.Add((ad)UnityEngine.Random.Range(0, 2));
        }
        Debug.Log(arrows[currentClicks]);
    }

    private void Update()
    {
        barValue = Mathf.Lerp(minimum, maximum, t);

        t += 0.5f * Time.deltaTime * speed / (requiredClicks+2);

        if (t > 1.0f || barValue > currentClicks + hitAccuracy)
        {
            OnLoseEvent?.Invoke(this, null);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsuItem : MonoBehaviour
{
    [SerializeField]
    private OsuLogic logic;
    public event EventHandler<bool> OnPulledUpEvent;
    private float hitAccuracy;
    private float speed;
    private bool start;
    private float startValue = 1f;
    private float endValue = 0f;
    private float t = 0f;
    private float circleValue = 2f;
    void Start()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<OsuLogic>();
        }
        logic.NewPepper(this);
    }

    private void Update()
    {
        if(!start) return;
        circleValue = Mathf.Lerp(startValue, endValue, t);

        t += 0.5f * Time.deltaTime * speed;

        if (t > 1.0f)
        {
            OnPulledUpEvent?.Invoke(this, false);
        }
    }

    public void Click()
    {
        if(circleValue > hitAccuracy)
        {
            OnPulledUpEvent?.Invoke(this, false);
            return;
        }
        OnPulledUpEvent?.Invoke(this, true);
        gameObject.SetActive(false);
        start = false;
    }

    public void StartAction(float speed, float accuracy)
    {
        this.speed = speed;
        this.hitAccuracy = accuracy;
        start = true;
    }
}

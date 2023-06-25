using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OsuItem : MonoBehaviour
{
    [SerializeField]
    private OsuLogic logic;
    [SerializeField]
    private Vector2 scaleRange;
    [SerializeField]
    private RectTransform indicator;
    [SerializeField]
    private RectTransform innerTarget;
    [SerializeField]
    private RectTransform outerTarget;
    public event EventHandler<bool> OnPulledUpEvent;
    private Vector2 hitAccuracy;
    private float speed;
    private bool start;
    private float startValue = 1f;
    private float endValue = 0f;
    private float t = 0f;
    private float circleValue = 2f;
    void Awake()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<OsuLogic>();
        }
        logic.NewPepper(this);
        indicator.gameObject.SetActive(false);
        innerTarget.gameObject.SetActive(false);
        outerTarget.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!start) return;
        circleValue = Mathf.Lerp(startValue, endValue, t);

        t += 0.5f * Time.deltaTime * speed;

        float scale = Mathf.Lerp(scaleRange.y, scaleRange.x, t);
        indicator.localScale = new Vector3(scale, scale);

        if (t > 1.0f)
        {
            OnPulledUpEvent?.Invoke(this, false);
        }
    }

    public void Click()
    {
        if(circleValue > hitAccuracy.y || circleValue < hitAccuracy.x)
        {
            OnPulledUpEvent?.Invoke(this, false);
            return;
        }
        OnPulledUpEvent?.Invoke(this, true);
        gameObject.SetActive(false);
        start = false;
    }

    public void StartAction(float speed, Vector2 accuracy)
    {
        this.speed = speed;
        this.hitAccuracy = accuracy;
        start = true;
        indicator.gameObject.SetActive(true);
        innerTarget.gameObject.SetActive(true);
        outerTarget.gameObject.SetActive(true);

        float minScale = Mathf.Lerp(scaleRange.x, scaleRange.y, hitAccuracy.x);
        float maxScale = Mathf.Lerp(scaleRange.x, scaleRange.y, hitAccuracy.y);
        innerTarget.localScale = new Vector3(minScale, minScale);
        outerTarget.localScale = new Vector3(maxScale, maxScale);
    }
}

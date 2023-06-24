using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamLeftRightLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private float angle = 20;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController clicksCounter;
    [SerializeField]
    private RectTransform turnip;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;
    private wasd keyToClick;
    private float startAngle;

    private enum wasd
    {
        w, a, s, d
    }

    public void IncreaseClicks(string key)
    {
        if (key == keyToClick.ToString())
        {
            currentClicks++;
            clicksCounter.ChangeValue(currentClicks, requiredClicks);
            turnip.rotation = Quaternion.Euler(0, 0, (keyToClick == wasd.a ? angle : -angle) + startAngle);

            keyToClick = keyToClick == wasd.a ? wasd.d : wasd.a;
            Debug.Log(currentClicks);
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
        }

    }

    private void Start()
    {
        keyToClick = wasd.a;
        startAngle = turnip.rotation.eulerAngles.z;
        clicksCounter.ChangeValue(0, 1);
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
}

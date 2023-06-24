using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SpamUpLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float reduceClicksCooldown = 1f;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController clickCounter;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;

    public void IncreaseClicks()
    {
        currentClicks++;
        clickCounter.ChangeValue(currentClicks, requiredClicks);
        Debug.Log(currentClicks);
        if (currentClicks >= requiredClicks)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    private void Start()
    {
        clickCounter.ChangeValue(currentClicks, requiredClicks);
        timer.ChangeValueInverted(0, timeLimit);
        StartCoroutine(ReduceClicksCourutine());
        StartCoroutine(TimeCourutine());
    }

    private IEnumerator ReduceClicksCourutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(reduceClicksCooldown);
            if (currentClicks > 0)
            {
                currentClicks--;
                clickCounter.ChangeValue(currentClicks, requiredClicks);
            }
        }
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

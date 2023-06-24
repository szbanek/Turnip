using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamUpLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float reduceClicksCooldown = 1f;
    [SerializeField]
    private float timeLimit = 10;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;

    public void IncreaseClicks()
    {
        currentClicks++;
        Debug.Log(currentClicks);
        if (currentClicks >= requiredClicks)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    private void Start()
    {
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
            }
        }
    }

    private IEnumerator TimeCourutine()
    {
        for (int i = 0; i <= timeLimit; i++)
        {
            yield return new WaitForSeconds(1);
        }
        OnLoseEvent?.Invoke(this, null);
    }
}

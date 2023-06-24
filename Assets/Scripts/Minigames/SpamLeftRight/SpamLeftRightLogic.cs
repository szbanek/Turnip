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
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;
    private wasd keyToClick;
    private enum wasd
    {
        w, a, s, d
    }

    public void IncreaseClicks(string key)
    {
        if (key == keyToClick.ToString())
        {
            currentClicks++;
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
        StartCoroutine(TimeCourutine());
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
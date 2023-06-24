using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float timeLimit = 10;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;
    private List<wasd> keyToClick;
    private enum wasd
    {
        w, a, s, d
    }

    public void IncreaseClicks(string key)
    {
        if (key == keyToClick[currentClicks].ToString())
        {
            currentClicks++;
            // Debug.Log(currentClicks);
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
            else
            {
                Debug.Log(keyToClick[currentClicks]);
            }
        }

    }

    private void Start()
    {
        keyToClick = new List<wasd>();
        for (int i = 0; i < requiredClicks; i++)
        {
            keyToClick.Add((wasd)UnityEngine.Random.Range(0, 4));
        }
        Debug.Log(keyToClick[0]);
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

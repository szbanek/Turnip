using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdClickLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private float timePenalty = 2f;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController clicksCounter;
    [SerializeField]
    private SerializedDictionary<wasd, UIImageColorer> keyImages;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;
    private float counter = 0;
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
            clicksCounter.ChangeValue(currentClicks, requiredClicks);
            keyImages[keyToClick].DecolorImage();
            keyToClick = (wasd)UnityEngine.Random.Range(0, 4);
            keyImages[keyToClick].ColorImage();
            Debug.Log(currentClicks);
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
        }
        else
        {
            counter += timePenalty;
            timer.ChangeValueInverted(counter, timeLimit);
        }
    }

    private void StartManual()
    {
        keyToClick = (wasd)UnityEngine.Random.Range(0, 4);
        keyImages[keyToClick].ColorImage();
        clicksCounter.ChangeValue(0, 1);
        timer.ChangeValueInverted(0, 1);
        StartCoroutine(TimeCourutine());
    }

    private IEnumerator TimeCourutine()
    {
        while ((counter += Time.deltaTime) < timeLimit)
        {
            timer.ChangeValueInverted(counter, timeLimit);
            yield return null;
        }
        OnLoseEvent?.Invoke(this, null);
    }

    public void SetDifficulty(float difficulty)
    {
        requiredClicks = (int)(Math.Max(requiredClicks - difficulty, 1));
        timeLimit += difficulty;
        timePenalty = (int)(Math.Max(timePenalty - difficulty, 0));
        StartManual();
    }
}

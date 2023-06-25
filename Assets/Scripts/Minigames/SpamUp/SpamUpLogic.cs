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
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController clickCounter;
    [SerializeField]
    private RectTransform carrot;
    private Vector2 YSpan = Vector2.zero;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;

    public void IncreaseClicks()
    {
        currentClicks++;
        ChangedValue();
        if (currentClicks >= requiredClicks)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    private void StartManual()
    {
        YSpan.x = carrot.position.y;
        YSpan.y = carrot.position.y + carrot.rect.height / 2;
        ChangedValue();
        timer.ChangeValueInverted(0, timeLimit);
        StartCoroutine(ReduceClicksCourutine());
        StartCoroutine(TimeCourutine());
    }

    private void ChangedValue()
    {
        Vector3 newPos = carrot.position;
        newPos.y = Mathf.Lerp(YSpan.x, YSpan.y, (float)currentClicks / (float)requiredClicks);
        carrot.position = newPos;
        clickCounter.ChangeValue(currentClicks, requiredClicks);
    }

    private IEnumerator ReduceClicksCourutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(reduceClicksCooldown);
            if (currentClicks > 0)
            {
                currentClicks--;
                ChangedValue();
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

    public void SetDifficulty(float difficulty)
    {
        requiredClicks = (int)(Math.Max(requiredClicks - difficulty, 1));
        timeLimit += difficulty;
        reduceClicksCooldown += difficulty/10;
        StartManual();
    }
}

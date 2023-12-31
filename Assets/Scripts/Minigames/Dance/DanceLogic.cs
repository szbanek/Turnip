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
    [SerializeField]
    private float height = 100;
    [SerializeField]
    private RectTransform aTurnip;
    [SerializeField]
    private RectTransform dTurnip;
    [SerializeField]
    private RectTransform turnip;
    [SerializeField]
    private UIBarController counter;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private List<ad> arrows = new List<ad>();
    private int currentClicks = 0;
    private float minimum = -1.0f;
    private float maximum;
    private float t = 0f;
    private float barValue = 0f;
    private Vector3 turnipDestination = Vector3.zero;
    private Vector3 turnipStart = Vector3.zero;
    private enum ad
    {
        a, d
    }

    public void Click(string key)
    {
        if (key == arrows[currentClicks].ToString() && Math.Abs(aTurnip.position.y - turnip.position.y) < height*hitAccuracy)
        {
            currentClicks++;
            counter.ChangeValue(currentClicks, requiredClicks);
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
            else
            {
                SpawnTurnip();
            }
        }
        else
        {
            OnLoseEvent?.Invoke(this, null);
        }
    }

    private void StartManual()
    {
        counter.ChangeValue(0, 1);
        maximum = requiredClicks + 1;
        for (int i = 0; i < requiredClicks; i++)
        {
            arrows.Add((ad)UnityEngine.Random.Range(0, 2));
        }
        SpawnTurnip();
    }

    private void Update()
    {
        barValue = Mathf.LerpUnclamped(minimum, maximum, t);

        t += 0.5f * Time.deltaTime * speed / (requiredClicks + 2);

        turnip.position = Vector3.LerpUnclamped(turnipStart, turnipDestination, barValue - currentClicks + 1 + hitAccuracy);

        if (barValue > currentClicks + hitAccuracy)
        {
            OnLoseEvent?.Invoke(this, null);
        }
    }

    private void SpawnTurnip()
    {
        switch (arrows[currentClicks])
        {
            case ad.a:
                turnipDestination = aTurnip.position;
                break;
            case ad.d:
                turnipDestination = dTurnip.position;
                break;
        }
        turnipDestination.y += 5;
        turnipStart = turnipDestination;
        turnipStart.y -= height;
        turnip.position = turnipStart;
    }

    public void SetDifficulty(float difficulty)
    {
        requiredClicks = (int)(Math.Max(requiredClicks - difficulty, 1));
        speed = Math.Max(speed - difficulty, 1f);
        hitAccuracy += difficulty / 10;
        StartManual();
    }
}

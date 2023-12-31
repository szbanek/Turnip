using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    [SerializeField]
    GameObject center;
    [SerializeField]
    private int requiredSpins = 10;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private UIBarController spins;
    [SerializeField]
    private RectTransform lettuce;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private float currentAngle = 0;
    private int currentSpins = 0;

    private float totalCurrentAngle => currentAngle + 360 * currentSpins;
    private float totalRequiredAngle => 360 * requiredSpins;

    public void Move(Vector2 vector)
    {
        Vector3 tmp = center.transform.position - new Vector3(vector.x, vector.y, 0);
        float angle = SignedAngleBetween(center.transform.position, tmp);
        if (angle>currentAngle)
        {
            currentAngle = angle;
        }
        else if(360 - currentAngle < 20 && angle < 20)
        {
            currentAngle = angle;
            currentSpins++;
        }
        spins.ChangeValue(totalCurrentAngle, totalRequiredAngle);
        lettuce.rotation = Quaternion.Euler(0, 0, -totalCurrentAngle);
        if (currentSpins >= requiredSpins)
        {
            OnWinEvent?.Invoke(this, null);
        }
    }

    private void StartManual()
    {
        spins.ChangeValue(0, 1);
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

    float SignedAngleBetween(Vector3 a, Vector3 b)
    {
        float angle = Vector3.SignedAngle(a, b, Vector3.forward); //Returns the angle between -180 and 180.
        if (angle < 0)
        {
            angle = 360 - angle * -1;
        }
        return (360-angle);
    }

    public void SetDifficulty(float difficulty)
    {
        requiredSpins = (int)(Math.Max(requiredSpins - difficulty, 1));
        timeLimit += difficulty;
        StartManual();
    }
}

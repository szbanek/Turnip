using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLogic : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private SnakeItem snake;
    private float counter = 0;
    private wasd currentDirection;
    private enum wasd
    {
        w, a, s, d
    }

    public void Click(string key)
    {
        wasd wasdKey;
        switch (key)
        {
            case "w":
                wasdKey = wasd.w;
                break;
            case "a":
                wasdKey = wasd.a;
                break;
            case "s":
                wasdKey = wasd.s;
                break;
            case "d":
                wasdKey = wasd.d;
                break;
            default:
                wasdKey = wasd.w;
                break;
        }
        if (((int)wasdKey + (int)currentDirection) % 2 == 1)
        {
            currentDirection = wasdKey;
            UpdateRotation();
        }
    }

    private void Start()
    {
        currentDirection = wasd.w;
        snake.OnGoalReachedEvent += (_, win) => HandleEvent(win);
        timer.ChangeValueInverted(0, 1);
        StartCoroutine(TimeCourutine());
    }

    private void UpdateRotation()
    {
        switch (currentDirection)
        {
            case wasd.w:
                snake.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case wasd.a:
                snake.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case wasd.s:
                snake.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case wasd.d:
                snake.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            default:
                break;
        }
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

    public void NewSnake(SnakeItem snakeItem)
    {
        snake = snakeItem;
    }

    private void HandleEvent(bool win)
    {
        if(win) OnWinEvent?.Invoke(this, null);
        else OnLoseEvent?.Invoke(this, null);
    }
}

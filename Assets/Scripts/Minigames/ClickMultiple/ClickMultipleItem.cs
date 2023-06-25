using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMultipleItem : MonoBehaviour
{
    [SerializeField]
    private ClickMultipleLogic logic;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private RectTransform gameArea;
    public event EventHandler OnPulledUpEvent;
    private Vector3 direction;
    private float rightBoundary;
    private float leftBoundary;
    private float upperBoundary;
    private float lowerBoundary;

    private void Start()
    {
        direction = Vector3.zero;
    }
    private void StartManual()
    {
        direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized * speed;
        if (logic == null)
        {
            logic = GetComponentInParent<ClickMultipleLogic>();
        }
        logic.NewPepper(this);
        RectTransform pepperTransform = transform as RectTransform;
        rightBoundary = gameArea.position.x + gameArea.rect.xMax - (pepperTransform.rect.width * Mathf.Sqrt(2)) / 2;
        leftBoundary = gameArea.position.x + gameArea.rect.xMin + (pepperTransform.rect.width * Mathf.Sqrt(2)) / 2;
        upperBoundary = gameArea.position.y + gameArea.rect.yMax - (pepperTransform.rect.width * Mathf.Sqrt(2)) / 2;
        lowerBoundary = gameArea.position.y + gameArea.rect.yMin + (pepperTransform.rect.width * Mathf.Sqrt(2)) / 2;
    }
    private void Update()
    {
        transform.position += direction;
        if (transform.position.x <= leftBoundary || transform.position.x >= rightBoundary)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y <= lowerBoundary || transform.position.y >= upperBoundary)
        {
            direction.y = -direction.y;
        }
    }

    public void clickMultiple()
    {
        OnPulledUpEvent?.Invoke(this, null);
    }

    public void SetDifficulty(float difficulty)
    {
        speed = (int)(Math.Max(speed - difficulty / 10, 0.1));
        StartManual();
    }
}

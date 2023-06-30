using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CatchItem : MonoBehaviour
{
    [SerializeField]
    private CatchLogic logic;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private RectTransform gameArea;
    public event EventHandler<bool> OnPulledUpEvent;
    private Vector3 direction;
    private float rightBoundary;
    private float leftBoundary;
    private float upperBoundary;
    private float lowerBoundary;

    private void Awake()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<CatchLogic>();
        }
        logic.NewLettuce(this);
    }
    private void StartManual()
    {
        direction = Vector3.down;

        RectTransform lettuceTransform = transform as RectTransform;
        rightBoundary = gameArea.position.x + gameArea.rect.xMax - (lettuceTransform.rect.width);
        leftBoundary = gameArea.position.x + gameArea.rect.xMin + (lettuceTransform.rect.width);
        upperBoundary = gameArea.position.y + gameArea.rect.yMax - (lettuceTransform.rect.width);
        lowerBoundary = gameArea.position.y + gameArea.rect.yMin + (lettuceTransform.rect.width);
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x <= leftBoundary || transform.position.x >= rightBoundary)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y >= upperBoundary)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y <= lowerBoundary)
        {
            OnPulledUpEvent?.Invoke(null, false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnPulledUpEvent?.Invoke(this, true);
        this.gameObject.SetActive(false);
    }

    public void SetDifficulty(float difficulty)
    {
        speed = Math.Max(speed - difficulty / 10, 0.1f);
        StartManual();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SnakeItem : MonoBehaviour
{
    [SerializeField]
    private SnakeLogic logic;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private GameObject goalZone;
    RectTransform goalTransform; 
    public event EventHandler<bool> OnGoalReachedEvent;
    void Awake()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<SnakeLogic>();
        }
        logic.NewSnake(this);
        goalTransform = goalZone.transform as RectTransform;
    }
    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        Vector2 snakePosition = goalTransform.InverseTransformPoint(transform.position);
        if (goalTransform.rect.Contains(snakePosition))
        {
            OnGoalReachedEvent?.Invoke(this, true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnGoalReachedEvent?.Invoke(this, false);
    }

    public void SetDifficulty(float difficulty)
    {
        speed = Math.Max(speed - difficulty/10, 0.1f);
    }
}

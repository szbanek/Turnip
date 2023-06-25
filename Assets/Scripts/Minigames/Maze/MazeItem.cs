using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MazeItem : MonoBehaviour
{
    [SerializeField]
    private MazeLogic logic;
    [SerializeField]
    private float xSpeed = 1f;
    [SerializeField]
    private float upSpeed = 1f;
    public event EventHandler<bool> OnGoalReachedEvent;
    private float goalHeight;
    private bool left = false;
    private bool moving = false;
    void Awake()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<MazeLogic>();
        }
        logic.NewLettuce(this);
        RectTransform logicTransform = logic.transform as RectTransform;
        goalHeight = logicTransform.rect.yMax;
    }
    private void Update()
    {
        float x = moving ? xSpeed : 0;
        x = left ? -x : x;
        transform.position += new Vector3(x, upSpeed, 0) * Time.deltaTime;
        if (transform.localPosition.y > goalHeight)
        {
            OnGoalReachedEvent?.Invoke(this, true);
        }
    }

    public void NotMoving()
    {
        this.moving = false;
    }

    public void SetMovement(bool left)
    {
        this.left = left;
        this.moving = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnGoalReachedEvent?.Invoke(this, false);
    }

    public void SetDifficulty(float difficulty)
    {
        upSpeed = (int)(Math.Max(upSpeed - difficulty/10, 0.1));
        xSpeed += difficulty/10;
    }
}

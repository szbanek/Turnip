using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MazeItem : MonoBehaviour
{
    [SerializeField]
    private MazeLogic logic;
    [SerializeField]
    private float speed = 1f;
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
        goalHeight = logicTransform.rect.yMax - logicTransform.rect.yMin - (transform as RectTransform).rect.height / 2;
    }
    private void Update()
    {
        float x = moving ? 0.1f * speed : 0;
        x = left ? -x : x;
        transform.position += new Vector3(x, 0.1f, 0);
        if (transform.position.y > goalHeight)
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
}

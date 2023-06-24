using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class HardestGameItem : MonoBehaviour
{
    [SerializeField]
    private HardestGameLogic logic;
    [SerializeField]
    private GameObject goalZone;
    public event EventHandler<bool> OnGoalReachedEvent;
    private bool held = false;
    void Start()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<HardestGameLogic>();
        }
        logic.NewLettuce(this);
    }

    public void UpdatePos(Vector2 vector)
    {
        if (!held) return;
        transform.position = new Vector3(vector.x, vector.y, 0);
        RectTransform rectTransform = goalZone.transform as RectTransform;
        Vector2 lettucePosition = rectTransform.InverseTransformPoint(transform.position);
        if (rectTransform.rect.Contains(lettucePosition))
        {
            OnGoalReachedEvent?.Invoke(this, true);
        }
    }


    public void SetHeld(bool held)
    {
        this.held = held;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnGoalReachedEvent?.Invoke(this, false);
    }
}

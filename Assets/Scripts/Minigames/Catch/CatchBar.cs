using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CatchBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform gameArea;
    [SerializeField]
    private CatchLogic logic;
    private float rightBoundary;
    private float leftBoundary;

    private void Awake()
    {
        if (logic == null)
        {
            logic = GetComponentInParent<CatchLogic>();
        }
        logic.NewBar(this);
    }
    private void Start()
    {
        RectTransform pepperTransform = transform as RectTransform;
        rightBoundary = gameArea.position.x + gameArea.rect.xMax - (pepperTransform.rect.width) / 2;
        leftBoundary = gameArea.position.x + gameArea.rect.xMin + (pepperTransform.rect.width) / 2;
    }

    public void UpdatePos(Vector2 vector)
    {
        float tmp = Math.Max(leftBoundary, vector.x);
        tmp = Math.Min(tmp, rightBoundary);
        transform.position = new Vector3(tmp, transform.position.y, transform.position.z);
    }
}

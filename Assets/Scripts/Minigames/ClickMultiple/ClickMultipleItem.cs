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
    public event EventHandler OnPulledUpEvent;
    private Vector3 direction;
    private float rightBoundary;
    private float leftBoundary;
    private float upperBoundary;
    private float lowerBoundary;
    void Start()
    {
        direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized * speed;
        if (logic == null)
        {
            logic = GetComponentInParent<ClickMultipleLogic>();
        }
        logic.NewPepper(this);
        RectTransform logicTransform = logic.transform as RectTransform;
        RectTransform pepperTransform = transform as RectTransform;
        rightBoundary = logicTransform.rect.xMax - logicTransform.rect.xMin - pepperTransform.rect.width/2;
        leftBoundary = pepperTransform.rect.width/2;
        upperBoundary = logicTransform.rect.yMax - logicTransform.rect.yMin - pepperTransform.rect.height/2;
        lowerBoundary = pepperTransform.rect.height/2;
    }
    private void Update()
    {
        transform.position += direction;
        if(transform.position.x <= leftBoundary || transform.position.x >= rightBoundary)
        {
            direction.x = -direction.x;
        }
        if(transform.position.y <= lowerBoundary || transform.position.y >= upperBoundary)
        {
            direction.y = -direction.y;
        }
    }

    public void clickMultiple()
    {
        OnPulledUpEvent?.Invoke(this, null);
    }
}

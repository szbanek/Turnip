using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullUpItem : MonoBehaviour
{
    [SerializeField]
    private PullUpLogic logic;
    private float pullUpDistance;
    public event EventHandler OnPulledUpEvent;
    private Vector3 initialPosition;
    private bool held = false;
    void Start()
    {
        pullUpDistance = (transform as RectTransform).rect.height;
        initialPosition = transform.position;
        if(logic==null)
        {
            logic = GetComponentInParent<PullUpLogic>();
        }
        logic.NewCarrot(this);
    }

    public void UpdatePos(Vector2 vector)
    {
        if(!held) return;
        if(transform.position.y > vector.y) return;
        transform.position = new Vector3(transform.position.x, vector.y, transform.position.z);
        if (Vector3.Distance(initialPosition, transform.position) > pullUpDistance)
        {
            OnPulledUpEvent?.Invoke(this, null);
            gameObject.SetActive(false);
        }
    }
    

    public void SetHeld(bool held)
    {
        this.held = held;
    }
}

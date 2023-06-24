using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    [SerializeField]
    private ClickLogic logic;
    public event EventHandler OnPulledUpEvent;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
        if (logic == null)
        {
            logic = GetComponentInParent<ClickLogic>();
        }
        logic.NewPepper(this);
    }

    public void Click()
    {
        OnPulledUpEvent?.Invoke(this, null);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class UITooltipMovement : MonoBehaviour
{
    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        image = GetComponent<Image>();
        UpdatePosition();
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadUnprocessedValue();
        Vector2 trueSize = rectTransform.sizeDelta * UIHUDController.Instance.UICanvas.scaleFactor;
        Vector2 pivot = Vector2.zero;
        if (trueSize.y + mousePosition.y > Screen.height)
        {
            pivot.y = 1;
        }
        else
        {
            pivot.y = 0;
        }
        if (mousePosition.x < trueSize.x)
        {
            pivot.x = 0;
        }
        else
        {
            pivot.x = 1;
        }
        rectTransform.pivot = pivot;
        rectTransform.position = mousePosition;
    }
}

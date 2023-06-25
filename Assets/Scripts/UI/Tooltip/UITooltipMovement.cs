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

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadUnprocessedValue();
        rectTransform.position = mousePosition;
        Vector2 pivot = new Vector2(mousePosition.x/Screen.width, mousePosition.y / Screen.height);
        rectTransform.pivot = pivot;
    }
}

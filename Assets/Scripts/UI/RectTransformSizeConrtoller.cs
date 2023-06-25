using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectTransformSizeConrtoller : MonoBehaviour
{
    [SerializeField]
    private float padding;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = transform as RectTransform;
    }

    private void Update()
    {
        float dim = Mathf.Min(Camera.main.pixelHeight, Camera.main.pixelWidth);
        float size =  dim - padding * 2;
        float width = (1 - dim / Camera.main.pixelWidth) / 2;
        float height = (1 - dim / Camera.main.pixelHeight) / 2;
        rectTransform.anchorMax = new Vector2(1 - width, 1 - height);
        rectTransform.anchorMin = new Vector2(width, height);
    }
}

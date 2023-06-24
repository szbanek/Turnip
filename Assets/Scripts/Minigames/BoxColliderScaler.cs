using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderScaler : MonoBehaviour
{
    private void Start()
    {
        RectTransform rectTransform = transform as RectTransform;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.offset = Vector2.zero;
        boxCollider2D.size = rectTransform.rect.size;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHUDController : Singleton<UIHUDController>
{
    [Header("References")]
    [SerializeField]
    private RectTransform interactionIconCanvas;

    public RectTransform InteractionIconCanvas => interactionIconCanvas;
}

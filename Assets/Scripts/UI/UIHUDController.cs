using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHUDController : Singleton<UIHUDController>
{
    [Header("References")]
    [SerializeField]
    private RectTransform interactionIconCanvas;
    [SerializeField]
    private RectTransform minigamePanel;
    [SerializeField]
    private RectTransform minigameCanvas;
    [SerializeField]
    private UIBarController staminaBar;

    public RectTransform InteractionIconCanvas => interactionIconCanvas;
    public RectTransform MinigamePanel => minigamePanel;
    public RectTransform MinigameCanvas => minigameCanvas;
    public UIBarController StaminaBar => staminaBar;
}

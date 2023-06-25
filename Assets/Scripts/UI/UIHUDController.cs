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
    [SerializeField]
    private UIMenuVisibilityManager menuVisibilityManager;
    [SerializeField]
    private RectTransform npcPanel;
    [SerializeField]
    private RectTransform npcCanvas;

    public RectTransform InteractionIconCanvas => interactionIconCanvas;
    public RectTransform MinigamePanel => minigamePanel;
    public RectTransform MinigameCanvas => minigameCanvas;
    public UIBarController StaminaBar => staminaBar;
    public UIMenuVisibilityManager MenuVisibilityManager => menuVisibilityManager;
    public RectTransform NPCPanel => npcPanel;
    public RectTransform NPCCanvas => npcCanvas;
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;
using UnityEngine.UI;

public class InteractionIconController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float fadeDuration;

    [Header("References")]
    [SerializeField]
    private Text text;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private CanvasGroup canvasGroup;

    public event System.EventHandler OnHideEvent;

    private Vector3 followedPosition = Vector3.zero;

    private bool isShown = false;

    public void ShowIcon(InteractionIconData data, Vector3 position)
    {
        text.text = data.Text;
        icon.sprite = data.Icon;
        followedPosition = position;
        isShown = true;
        StartCoroutine(UIUtils.CanvasGroupFadeCoroutine(canvasGroup, fadeDuration, UIUtils.Fade.FadeIn, () => isShown));
    }

    public void HideIcon()
    {
        StartCoroutine(HideCoroutine());
    }

    private IEnumerator HideCoroutine()
    {
        yield return StartCoroutine(UIUtils.CanvasGroupFadeCoroutine(canvasGroup, fadeDuration, UIUtils.Fade.FadeOut));
        OnHideEvent?.Invoke(this, null);
    }

    private void LateUpdate()
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(followedPosition);

        transform.position = new Vector3(screenPoint.x, screenPoint.y, transform.position.z);
    }
}

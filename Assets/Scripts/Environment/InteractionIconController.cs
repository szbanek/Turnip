using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionIconController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Image icon;

    public event System.EventHandler OnHideEvent;

    private Vector3 followedPosition = Vector3.zero;

    public void ShowIcon(InteractionIconData data, Vector3 position)
    {
        text.text = data.Text;
        icon.sprite = data.Icon;
        followedPosition = position;
    }

    public void HideIcon()
    {
        OnHideEvent?.Invoke(this, null);
    }

    private void LateUpdate()
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(followedPosition);

        transform.position = new Vector3(screenPoint.x, screenPoint.y, transform.position.z);
    }
}

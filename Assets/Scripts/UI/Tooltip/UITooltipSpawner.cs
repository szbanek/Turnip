using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITooltipSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject tooltipPrefab;

    private GameObject tooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip = Instantiate(tooltipPrefab, transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(tooltip);
    }
}

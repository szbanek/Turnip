using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITooltipSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject tooltipPrefab;

    private GameObject tooltip;

    private ItemInstance item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip = Instantiate(tooltipPrefab, transform);
        UITooltipContentManager contentManager = tooltip.GetComponent<UITooltipContentManager>();
        contentManager.SetContent(item.Name, item.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(tooltip);
    }

    public void SetItemInstance(ItemInstance item)
    {
        this.item = item;
    }
}

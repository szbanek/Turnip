using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(UITooltipSpawner))]
public class UIItemSlot : MonoBehaviour
{
    private ItemInstance item;
    public ItemInstance Item
    {
        get => item;
        set
        {
            item = value;
            OnItemSet();
        }
    }

    private Image image;
    private Button button;
    private UITooltipSpawner tooltipSpawner;

    public event System.EventHandler<ItemInstance> OnItemPressed;

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        tooltipSpawner = GetComponent<UITooltipSpawner>();
        button.onClick.AddListener(OnClick);
        OnItemSet();
    }

    private void OnItemSet()
    {
        if (item == null)
        {
            image.color = Color.clear;
            button.interactable = false;
            tooltipSpawner.enabled = false;
        }
        else
        {
            image.sprite = item.Item.InventoryIcon;
            image.color = Color.white;
            button.interactable = true;
            tooltipSpawner.enabled = true;
        }
    }

    private void OnClick()
    {
        OnItemPressed?.Invoke(this, item);
    }
}

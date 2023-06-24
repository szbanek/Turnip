using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
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

    public event System.EventHandler<ItemInstance> OnItemPressed;

    public void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        OnItemSet();
    }

    private void OnItemSet()
    {
        if (item == null)
        {
            image.color = Color.clear;
            button.interactable = false;
        }
        else
        {
            image.sprite = item.Item.InventoryIcon;
            image.color = Color.white;
            button.interactable = true;
        }
    }

    private void OnClick()
    {
        OnItemPressed?.Invoke(this, item);
    }
}

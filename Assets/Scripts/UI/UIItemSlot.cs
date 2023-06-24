using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UIItemSlot : MonoBehaviour
{
    private PlayerItem item;
    public PlayerItem Item
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
            image.sprite = item.InventoryIcon;
            image.color = Color.white;
            button.interactable = true;
        }
    }

    private void OnClick()
    {
        Debug.Log("Clicked");
    }
}

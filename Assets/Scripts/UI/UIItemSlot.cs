using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
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

    public void Start()
    {
        image = GetComponent<Image>();
    }

    private void OnItemSet()
    {
        if (item == null)
        {
            image.color = Color.clear;
        }
        else
        {
            image.sprite = item.InventoryIcon;
            image.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on slot");
    }
}

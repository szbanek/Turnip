using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIMenuVisibilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;
    [SerializeField]
    private UIVegetableInventory vegetables;
    [SerializeField]
    private UIItemInventory items;

    private bool menuShown;

    private void Start()
    {
        HideMenu();
    }

    public void ShowMenu()
    {
        if (PauseScreen.Instance.Paused)
        {
            return;
        }

        menuShown = true;
        ApplyVisibilityChange();
    }

    public void HideMenu()
    {
        menuShown = false;
        ApplyVisibilityChange();
    }

    public void SwitchMenu()
    {
        if (PauseScreen.Instance.Paused)
        {
            return;
        }

        menuShown = !menuShown;
        ApplyVisibilityChange();
    }

    private void ApplyVisibilityChange()
    {
        menuObject.SetActive(menuShown);
        if (menuShown)
        {
            CursorManager.Instance.UnlockCursor();
            FindObjectOfType<PlayerInputAdapter>().EnableMovement = false;
            foreach (var item in FindObjectOfType<PlayerVegetableInventory>().Inventory)
            {
                vegetables.UpdateVegetable(item.Key, item.Value);
            }
            items.OnMenuEnabled();
        }
        else
        {
            CursorManager.Instance.LockCursor();
            FindObjectOfType<PlayerInputAdapter>().EnableMovement = true;
        }
    }
}

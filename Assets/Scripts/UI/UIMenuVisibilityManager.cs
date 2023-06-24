using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMenuVisibilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;

    private bool menuShown;

    private void Start()
    {
        HideMenu();
    }

    public void ShowMenu()
    {
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
        }
        else
        {
            CursorManager.Instance.LockCursor();
            FindObjectOfType<PlayerInputAdapter>().EnableMovement = true;
        }
    }
}

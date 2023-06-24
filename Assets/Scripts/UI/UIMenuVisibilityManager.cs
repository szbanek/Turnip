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
        menuObject.SetActive(true);
    }

    public void HideMenu()
    {
        menuShown = false;
        menuObject.SetActive(false);
    }

    public void SwitchMenu()
    {
        menuShown = !menuShown;
        menuObject.SetActive(menuShown);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuVisibilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;

    public void ShowMenu()
    {
        menuObject.SetActive(true);
    }

    public void HideMenu()
    {
        menuObject.SetActive(false);
    }
}

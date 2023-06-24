using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITabsController : MonoBehaviour
{
    public enum Tab
    {
        Vegetables,
        Inventory,
        Character
    }

    [Header("References")]
    [SerializeField]
    private SerializedDictionary<Tab, Button> buttons;
    [SerializeField]
    private SerializedDictionary<Tab, GameObject> screens;

    private Tab currentTab;

    private void Start()
    {
        currentTab = Tab.Inventory;
        ChangeTab(currentTab);

        InitButtons();
    }

    private void InitButtons()
    {
        foreach(var pair in buttons)
        {
            pair.Value.onClick.AddListener(() => ChangeTab(pair.Key));
        }
    }

    private void ChangeTab(Tab tab)
    {
        foreach (GameObject obj in screens.Values)
        {
            obj.SetActive(false);
        }
        screens[tab].SetActive(true);

        foreach (Button button in buttons.Values)
        {
            button.interactable = true;
        }
        buttons[tab].interactable = false;
    }
}

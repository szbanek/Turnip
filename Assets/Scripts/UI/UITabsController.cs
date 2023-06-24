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

    [Header("Sprites")]
    [SerializeField]
    private Sprite selectedTabButtonImage;

    private Tab currentTab;
    private Sprite defaultButtonImage;

    private void Start()
    {
        currentTab = Tab.Inventory;
        defaultButtonImage = buttons[currentTab].image.sprite;
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
            button.image.sprite = defaultButtonImage;
            button.interactable = true;
        }
        buttons[tab].image.sprite = selectedTabButtonImage;
        buttons[tab].interactable = false;
    }
}

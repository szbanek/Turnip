using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Singleton<PauseScreen>
{
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button changeLocale;

    [HideInInspector]
    public bool Paused { get; private set; } = false;

    private void Start()
    {
        quitButton.onClick.AddListener(Application.Quit);
        changeLocale.onClick.AddListener(LocaleManager.Instance.ChangeLocale);
        pauseScreen.SetActive(false);
    }

    public void SwitchPause()
    {
        Paused = !Paused;
        UIHUDController.Instance.MenuVisibilityManager.HideMenu();
        if (!Paused)
        {
            CursorManager.Instance.LockCursor();
        }
        else
        {
            CursorManager.Instance.UnlockCursor();
        }
        pauseScreen.SetActive(Paused);
        PlayerInputAdapter playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
        playerInputAdapter.EnableMovement = !Paused;
    }
}

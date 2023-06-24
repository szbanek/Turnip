using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : Singleton<MinigameManager>
{
    private RectTransform minigameCanvas;
    private RectTransform minigamePanel;
    private PlayerInputAdapter playerInputAdapter;

    private GameObject currentMinigame = null;
    private VegetableInteractionController currentMinigameSpawner = null;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
        minigamePanel = UIHUDController.Instance.MinigamePanel;
        playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
    }

    public void SpawnMinigame(GameObject minigame, VegetableInteractionController spawner)
    {
        CursorManager.Instance.UnlockCursor();
        minigamePanel.gameObject.SetActive(true);
        currentMinigame = Instantiate(minigame, minigameCanvas);
        currentMinigameSpawner = spawner;
        playerInputAdapter.inputAdapter = currentMinigame.GetComponent<IInputAdapter>();
        currentMinigame.GetComponent<IMinigameManager>().OnMinigameEndEvent += (_, e) => OnMinigameEnd(e);
    }

    private void OnMinigameEnd(bool win)
    {
        CursorManager.Instance.LockCursor();
        minigamePanel.gameObject.SetActive(false);
        playerInputAdapter.inputAdapter = null;
        Destroy(currentMinigame);
        currentMinigameSpawner.MinigameEnd(win);
    }
}

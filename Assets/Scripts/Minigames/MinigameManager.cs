using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : Singleton<MinigameManager>
{
    private RectTransform minigameCanvas;
    private RectTransform minigamePanel;
    private PlayerInputAdapter playerInputAdapter;

    private GameObject currentMinigame = null;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
        minigamePanel = UIHUDController.Instance.MinigamePanel;
        playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
    }

    public void SpawnMinigame(GameObject minigame)
    {
        minigamePanel.gameObject.SetActive(true);
        currentMinigame = Instantiate(minigame, minigameCanvas);
        playerInputAdapter.inputAdapter = currentMinigame.GetComponent<IInputAdapter>();
        currentMinigame.GetComponent<IMinigameManager>().OnMinigameEndEvent += (_, e) => OnMinigameEnd(e);
    }

    private void OnMinigameEnd(bool win)
    {
        minigamePanel.gameObject.SetActive(false);
        playerInputAdapter.inputAdapter = null;
        print(win ? "Juhu!!" : "Buuu!!!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : Singleton<MinigameManager>
{
    private RectTransform minigameCanvas;
    private RectTransform minigamePanel;
    private RectTransform npcCanvas;
    private RectTransform npcPanel;
    private PlayerInputAdapter playerInputAdapter;

    private GameObject currentMinigame = null;
    private VegetableInteractionController currentMinigameSpawner = null;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
        minigamePanel = UIHUDController.Instance.MinigamePanel;
        npcCanvas = UIHUDController.Instance.NPCCanvas;
        npcPanel = UIHUDController.Instance.NPCPanel;
        playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
        minigamePanel.gameObject.SetActive(false);
        npcPanel.gameObject.SetActive(false);
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

    public void SpawnMinigame(GameObject minigame, VegetableInteractionController spawner, Quest quest)
    {
        CursorManager.Instance.UnlockCursor();
        npcPanel.gameObject.SetActive(true);
        currentMinigame = Instantiate(minigame, npcCanvas);
        currentMinigame.GetComponent<NpcMinigameLogic>()?.SetQuest(quest);
        currentMinigameSpawner = spawner;
        playerInputAdapter.inputAdapter = currentMinigame.GetComponent<IInputAdapter>();
        currentMinigame.GetComponent<IMinigameManager>().OnMinigameEndEvent += (_, e) => OnMinigameEnd(e);
    }

    private void OnMinigameEnd(bool win)
    {
        CursorManager.Instance.LockCursor();
        minigamePanel.gameObject.SetActive(false);
        npcPanel.gameObject.SetActive(false);
        playerInputAdapter.inputAdapter = null;
        Destroy(currentMinigame);
        currentMinigameSpawner.MinigameEnd(win);
    }
}

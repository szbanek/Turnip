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
    private PlayerStats stats;

    private GameObject currentMinigame = null;
    private VegetableInteractionController currentMinigameSpawner = null;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
        minigamePanel = UIHUDController.Instance.MinigamePanel;
        npcCanvas = UIHUDController.Instance.NPCCanvas;
        npcPanel = UIHUDController.Instance.NPCPanel;
        playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
        stats = FindObjectOfType<PlayerStats>();
        minigamePanel.gameObject.SetActive(false);
        npcPanel.gameObject.SetActive(false);
    }

    public void SpawnMinigame(GameObject minigame, VegetableInteractionController spawner)
    {
        CursorManager.Instance.UnlockCursor();
        npcPanel.gameObject.SetActive(true);
        currentMinigame = Instantiate(minigame, npcCanvas);
        IMinigameManager manager = currentMinigame.GetComponent<IMinigameManager>();
        manager.SetDifficulty(stats.MinigameBonus/10);
        currentMinigameSpawner = spawner;
        playerInputAdapter.inputAdapter = currentMinigame.GetComponent<IInputAdapter>();
        manager.OnMinigameEndEvent += (_, e) => OnMinigameEnd(e);
    }

    public void SpawnMinigame(GameObject minigame, VegetableInteractionController spawner, Quest quest)
    {
        SpawnMinigame(minigame, spawner);
        currentMinigame.GetComponent<IMinigameManager>().SetQuest(quest);
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

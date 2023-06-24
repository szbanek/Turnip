using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private Transform minigameCanvas;
    private PlayerInputAdapter playerInputAdapter;

    private GameObject currentMinigame = null;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
        playerInputAdapter = FindObjectOfType<PlayerInputAdapter>();
    }

    public void SpawnMinigame(GameObject minigame)
    {
        currentMinigame = Instantiate(minigame, minigameCanvas);
        playerInputAdapter.inputAdapter = currentMinigame.GetComponent<IInputAdapter>();
        currentMinigame.GetComponent<IMinigameManager>().OnMinigameEndEvent += (_, e) => OnMinigameEnd(e);
    }

    private void OnMinigameEnd(bool win)
    {
        playerInputAdapter.inputAdapter = null;
        print(win ? "Juhu!!" : "Buuu!!!");
    }
}

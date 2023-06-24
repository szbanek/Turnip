using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private Transform minigameCanvas;

    private void Start()
    {
        minigameCanvas = UIHUDController.Instance.MinigameCanvas;
    }

    public void SpawnMinigame(GameObject minigame)
    {
        Instantiate(minigame, minigameCanvas);
    }
}

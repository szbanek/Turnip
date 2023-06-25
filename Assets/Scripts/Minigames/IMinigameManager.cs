using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinigameManager
{
    public event System.EventHandler<bool> OnMinigameEndEvent;
    public void SetDifficulty(float difficulty);
    public void SetQuest(Quest quest);
}

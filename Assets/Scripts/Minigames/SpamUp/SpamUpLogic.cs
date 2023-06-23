using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamUpLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float reduceClicksCooldown = 1f;
    [SerializeField]
    private float timeLimit = 10;
    private IMinigameManager manager;
    private int currentClicks = 0;

    public void IncreaseClicks()
    {
        currentClicks++;
        Debug.Log(currentClicks);
        if (currentClicks >= requiredClicks)
        {
            manager.EndMinigame(true);
        }
    }

    private void Start()
    {
        manager = GetComponent<IMinigameManager>();
        StartCoroutine(ReduceClicksCourutine());
        StartCoroutine(TimeCourutine());
    }

    private IEnumerator ReduceClicksCourutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(reduceClicksCooldown);
            if (currentClicks > 0)
            {
                currentClicks--;
            }
        }
    }

    private IEnumerator TimeCourutine()
    {
        for (int i = 0; i <= timeLimit; i++)
        {
            yield return new WaitForSeconds(1);
        }
        manager.EndMinigame(false);
    }
}

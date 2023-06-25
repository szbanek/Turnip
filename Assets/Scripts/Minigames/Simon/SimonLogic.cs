using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonLogic : MonoBehaviour
{
    [SerializeField]
    private int requiredClicks = 10;
    [SerializeField]
    private float timeLimit = 10;
    [SerializeField]
    private UIBarController timer;
    [SerializeField]
    private float lightupDuration;
    [SerializeField]
    private float downDuration;
    [SerializeField]
    private SerializedDictionary<wasd, UIImageColorer> keyImages;
    public event EventHandler OnWinEvent;
    public event EventHandler OnLoseEvent;
    private int currentClicks = 0;
    private List<wasd> keyToClick;
    private bool simonSays = false;
    private enum wasd
    {
        w, a, s, d
    }

    public void IncreaseClicks(string key)
    {
        if (simonSays)
        {
            return;
        }
        if (key == keyToClick[currentClicks].ToString())
        {
            if (currentClicks > 0)
            {
                keyImages[keyToClick[currentClicks - 1]].DecolorImage();
            }
            keyImages[keyToClick[currentClicks]].ColorImage();
            currentClicks++;
            if (currentClicks >= requiredClicks)
            {
                OnWinEvent?.Invoke(this, null);
            }
        }
        else
        {
            OnLoseEvent?.Invoke(this, null);
        }

    }

    private void StartManual()
    {
        keyToClick = new List<wasd>();
        for (int i = 0; i < requiredClicks; i++)
        {
            keyToClick.Add((wasd)UnityEngine.Random.Range(0, 4));
        }
        StartCoroutine(StartCourutine());
    }

    private IEnumerator StartCourutine()
    {
        simonSays = true;
        for (int i = 0; i < keyToClick.Count; i++)
        {
            yield return new WaitForSeconds(downDuration);
            keyImages[keyToClick[i]].ColorImage();
            yield return new WaitForSeconds(lightupDuration);
            keyImages[keyToClick[i]].DecolorImage();
        }
        simonSays = false;
        yield return StartCoroutine(TimeCourutine());
    }

    private IEnumerator TimeCourutine()
    {
        float counter = 0;
        while ((counter += Time.deltaTime) < timeLimit)
        {
            timer.ChangeValueInverted(counter, timeLimit);
            yield return null;
        }
        OnLoseEvent?.Invoke(this, null);
    }

    public void SetDifficulty(float difficulty)
    {
        requiredClicks = (int)(Math.Max(requiredClicks - difficulty, 1));
        timeLimit += difficulty;
        StartManual();
    }
}

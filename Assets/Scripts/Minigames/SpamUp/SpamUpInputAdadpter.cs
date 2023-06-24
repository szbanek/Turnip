using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpamUpInputAdadpter : MonoBehaviour, IInputAdapter
{
    private SpamUpLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<SpamUpLogic>();
    }

    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 deltaPos)
    {
        return;
    }

    public void KeyboardW(bool pressed)
    {
        return;
    }

    public void KeyboardA(bool pressed)
    {
        return;
    }

    public void KeyboardS(bool pressed)
    {
        return;
    }

    public void KeyboardD(bool pressed)
    {
        return;
    }

    public void MouseClick(bool pressed)
    {
        if (Stopped) return;
        if (pressed)
        {
            logic.IncreaseClicks();
            Debug.Log("increased");
        }
    }
}

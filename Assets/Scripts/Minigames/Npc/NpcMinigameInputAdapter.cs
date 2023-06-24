using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcMinigameInputAdapter : MonoBehaviour, IInputAdapter
{
    private NpcMinigameLogic logic;
    private Vector2 pos;
    private void Start()
    {
        logic = GetComponent<NpcMinigameLogic>();
    }
    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 deltaPos)
    {
        pos = deltaPos;
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
        if (pressed)
        {
            logic.Click(pos);
        }
    }
}
